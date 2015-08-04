using System;
using System.Collections.Generic;
using System.Linq;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Orders
{
    public class Order : BaseEntity
    {
        public OrderStates State { get; set; }

        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public int TotalPrice { get; set; }
        [ColumnDetail(Length = 12)]
        public string CouponItemId { get; set; }
        public string DiscountName { get; set; }
        public int Discount { get; set; }
        public string Currency { get; set; }
        public int ExchangeRate { get; set; }
        [ColumnDetail(Length = 12)]
        public string MemberAddressId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ApiSessionId { get; set; }
        public string DisplayName { get; set; }

        public DateTime OrderDate { get; set; }
        [ColumnDetail(Length = 12)]
        public string InvoiceCompanyId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        // PaymentGateway ödeme bilgisi
        public string PGHash { get; set; }


        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }
        public CouponItem CouponItem() { return Provider.ReadEntityWithRequestCache<CouponItem>(CouponItemId); }
        public MemberAddress MemberAddress() { return Provider.ReadEntityWithRequestCache<MemberAddress>(MemberAddressId); }
        public InvoiceCompany InvoiceCompany() { return Provider.ReadEntityWithRequestCache<InvoiceCompany>(InvoiceCompanyId); }

        public List<OrderItem> Items { get; set; }

        public static Order GetMemberBasket()
        {
            Order order = null;

            if (string.IsNullOrWhiteSpace(Provider.Api.Session.MemberId))
                order = Provider.Database.Read<Order>("ApiSessionId={0} AND State='Basket'", Provider.Api.Session.Id); // oturum açılmadan oluşturulan sepet
            else
                order = Provider.Database.Read<Order>("MemberId={0} AND State='Basket'", Provider.CurrentMember.Id); // son oturumda oluşturulan sepet

            if (order == null)
                order = new Order() { MemberId = Provider.CurrentMember.Id, ApiSessionId = Provider.Api.Session.Id}; // sepet yok, bir tane oluşturulsun

            if (string.IsNullOrWhiteSpace(order.Id))
                order.Items = new List<OrderItem>();
            else
                order.ReadItemsRecursive();

            if (order.Items.Count > 0)
            {
                // ürün fiyatlarını tekrar okuyalım. sepet çok eskiden kalmış, fiyatlar da değişmiş olabilir.
                var productPrices = Provider.Database.ReadList<ProductPrice>("select * from ProductPrice where Id in ('" + order.Items.Select(i => i.ProductPriceId).Distinct().StringJoin("','") + "')");
                foreach (var orderItem in order.Items)
                {
                    var productPrice = productPrices.FirstOrDefault(pp => pp.Id == orderItem.ProductPriceId);
                    if (productPrice == null)
                    {
                        orderItem.Price = 0;
                        continue;
                    }
                    orderItem.Price = (orderItem.Amount / productPrice.Amount) * productPrice.Price;
                }
            }

            order.CalculateTotalPrice();

            return order;
        }

        public void CalculateTotalPrice()
        {
            if (string.IsNullOrWhiteSpace(this.Currency) && this.Items.Count > 0)
                this.Currency = this.Items[0].Currency;

            var api = Provider.Api ?? new ApiJson();
            var member = this.Member();

            var rates = api.GetExchangeRates(null);

            this.TotalPrice = this.Items.Sum(i => (int)(i.Price * rates.GetRate(i.Currency, this.Currency)));

            if (string.IsNullOrWhiteSpace(this.CouponItemId) && member.MemberType == MemberTypes.Reseller)
            {
                var reseller = member.Reseller();
                if (reseller != null && reseller.IsResellerActive())
                {
                    this.DiscountName = reseller.ResellerType().Name;
                    this.Discount = this.TotalPrice * reseller.RebateRate / 100;
                }
            }

            this.TotalPrice -= this.Discount;
        }

        public OrderInfo ToOrderInfo()
        {
            var res = this.ToEntityInfo<OrderInfo>();
            res.Items = this.Items.ToEntityInfo<OrderItemInfo>();
            res.Address = this.MemberAddress().ToEntityInfo<MemberAddressInfo>();
            return res;
        }

        public void AddItem(OrderItemInfo orderItem)
        {
            if(string.IsNullOrWhiteSpace(orderItem.ProductPriceId))
                throw new APIException("Select a product price to add to the order");

            var productPrice = Provider.Database.Read<ProductPrice>("Id={0}", orderItem.ProductPriceId);
            if (productPrice == null)
                throw new APIException("No such product price");

            // henüz kaydedilmemişse sepeti kaydet
            if (string.IsNullOrWhiteSpace(this.Id))
                this.Save();

            var entityOrderItem = new OrderItem();
            productPrice.CopyPropertiesWithSameName(entityOrderItem);
            entityOrderItem.Id = orderItem.Id;
            entityOrderItem.Amount = orderItem.Amount == 0 ? productPrice.Amount : orderItem.Amount;
            entityOrderItem.Price = (entityOrderItem.Amount / productPrice.Amount) * productPrice.Price;
            entityOrderItem.ProductPriceId = productPrice.Id;

            entityOrderItem.OrderId = this.Id;
            entityOrderItem.DisplayName = entityOrderItem.Product().Name;
            entityOrderItem.Save();

            ReadItemsRecursive();

            if (string.IsNullOrWhiteSpace(MemberAddressId) && !string.IsNullOrWhiteSpace(MemberId))
                this.MemberAddressId = Provider.Database.GetString("SELECT MemberAddressId FROM Member WHERE Id={0}", MemberId);
            if (this.Items.Count == 1)
                this.DisplayName = entityOrderItem.DisplayName;
            if (string.IsNullOrWhiteSpace(this.Currency))
                this.Currency = "$";

            this.CalculateTotalPrice();

            this.Save();
        }

        public void ReadItemsRecursive()
        {
            var allItems = Provider.Database.ReadList<OrderItem>("SELECT * FROM OrderItem WHERE OrderId = {0}", this.Id);
            this.Items = new List<OrderItem>();
            if (allItems == null) return; //***

            foreach (var item in allItems)
            {
                if (string.IsNullOrWhiteSpace(item.ParentOrderItemId))
                {
                    readItemsRecursive(item, allItems);
                    this.Items.Add(item);
                }
            }
        }

        private void readItemsRecursive(OrderItem item, List<OrderItem> allItems)
        {
            item.Items = allItems.Where(i => i.ParentOrderItemId == item.Id).ToList();
            foreach (var subItem in item.Items)
                readItemsRecursive(subItem, allItems);
        }

        public void RemoveItem(string orderItemId)
        {
            RemoveItem(Provider.Database.Read<OrderItem>("Id={0}", orderItemId));
        }
        public void RemoveItem(OrderItem orderItem)
        {
            if (string.IsNullOrWhiteSpace(orderItem.Id))
                throw new APIException("No such order item");
            if (this.State != OrderStates.Basket)
                throw new Exception("This order cannot be changed. It's not a basket.");

            orderItem.Delete();

            ReadItemsRecursive();

            this.CalculateTotalPrice();

            this.Save();
        }


        public void RemoveAllItems()
        {
            if(this.State!= OrderStates.Basket)
                throw new Exception("This order cannot be emptied. It's not a basket.");

            Provider.Database.ExecuteNonQuery("DELETE FROM OrderItem WHERE OrderId={0}", this.Id);

            this.Items = new List<OrderItem>();
            this.Discount = 0;
            this.CouponItemId = "";
            this.TotalPrice = 0;
            this.Save();
        }


        public static Order GetMemberOrder(string orderId)
        {
            Order order = null;

            if (string.IsNullOrWhiteSpace(orderId))
            {
                order = Provider.Database.ReadList<Order>("SELECT * FROM [Order] WHERE MemberId={0} AND State='Order'", Provider.Api.Session.MemberId).OrderByDescending(o=>o.InsertDate).FirstOrDefault();
                if(order==null)
                    throw new APIException("No such order");
                order.ReadItemsRecursive();
                return order;
            }

            order = Provider.Database.Read<Order>("Id={0}", orderId);
            if ((Provider.Api!=null && order.MemberId != Provider.CurrentMember.Id) || order==null)
                throw new APIException("No such order");
            order.ReadItemsRecursive();
            return order;
        }

        public void AddJobsToQueue()
        {
            foreach (var workerType in typeof(BaseWorker).Assembly.GetTypes())
            {
                if (workerType.IsSubclassOf(typeof(BaseWorker)))
                {
                    var worker = (BaseWorker)Activator.CreateInstance(workerType);
                    worker.CreateJobsFor(this);
                }
            }
        }

        public override void Delete()
        {
            Provider.Database.Execute(() =>
            {
                foreach (OrderItem orderItem in Provider.Database.ReadList<OrderItem>("SELECT * FROM OrderItem WHERE OrderId={0} AND (ParentOrderItemId IS NULL OR ParentOrderItemId='')", this.Id))
                    orderItem.Delete();

                base.Delete();
            });
        }
    }

    public class ListViewOrder : Order
    {
        public string MemberEmail { get; set; }
        public string MemberState { get; set; }
        public string MemberMedal { get; set; }
        public string InvoiceCompanyName { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}