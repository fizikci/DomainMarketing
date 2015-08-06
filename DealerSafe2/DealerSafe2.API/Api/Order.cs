using System;
using System.Collections.Generic;
using System.Linq;
using DealerSafe2.API.Entity;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.EntityInfo.Jobs;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.API.Entity.Properties;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        #region Product

        public List<ProductInfo> GetProductListWithPropertyAndPrices(string ids)
        {
            var strOR = "(" + ids.Split(',').Select(i => "Id = " + i).StringJoin(" OR ") + ")";
            var res = Provider.Database.ReadList<Product>(@"
                                SELECT 
                                    Id,
                                    Name,
                                    IsFeatured
                                FROM 
                                    Product
                                WHERE 
                                    ApiId = {0} AND
                                    " + strOR + @" AND
                                    IsDeleted = 0
                                ORDER BY
                                    OrderNo
                            ", ApiClient.ApiId)
                              .ToEntityInfo<ProductInfo>();

            return addPropertyAndPrices(res);
        }
        public List<ProductInfo> GetProductListWithProductType(string productType)
        {
            var res = Provider.Database.ReadList<Product>(@"
                                SELECT 
                                    p.Id,
                                    p.Name,
                                    p.IsFeatured
                                FROM 
                                    Product p, Supplier s
                                WHERE 
                                    p.SupplierId = s.Id AND
                                    s.ApiId = {0} AND
                                    p.ProductTypeId = {1} AND
                                    p.IsDeleted = 0
                                ORDER BY
                                    p.OrderNo
                            ", ApiClient.ApiId, productType)
                              .ToEntityInfo<ProductInfo>();

            return addPropertyAndPrices(res);
        }
        public ProductInfo GetProductWithDetails(string id)
        {
            var res = Provider.Database.Read<Product>("Id={0}", id).ToEntityInfo<ProductInfo>();
            return addPropertyAndPrices(new List<ProductInfo>() { res })[0];
        }

        private static List<ProductInfo> addPropertyAndPrices(List<ProductInfo> res)
        {
            var properties = Provider.Database.ReadList<ListViewPropertyValue>("SELECT * FROM ListViewPropertyValue WHERE EntityName='Product' AND EntityId IN ('" + res.Select(p => p.Id).StringJoin("','") + "') ORDER BY OrderNo");
            var prices = Provider.Database.ReadList<ProductPrice>("SELECT * FROM ProductPrice WHERE ProductId IN ('" + res.Select(p => p.Id).StringJoin("','") + "')");

            foreach (var productInfo in res)
            {
                productInfo.ListProductPrice = prices.Where(p => p.ProductId == productInfo.Id).ToList().ToEntityInfo<ProductPriceInfo>();
                productInfo.Properties = properties.Where(p => p.EntityId == productInfo.Id).ToList().ToEntityInfo<ViewPropertyValueInfo>();
            }

            return res;
        }

        #endregion

        #region Basket

        public List<MemberAddressInfo> GetCheckoutAddressList(string req)
        {
            if (!string.IsNullOrWhiteSpace(this.Session.MemberId))
                return Provider.Database.ReadList<MemberAddress>("select * from MemberAddress where MemberId={0} AND IsDeleted=0", this.Session.MemberId).ToEntityInfo<MemberAddressInfo>();

            return new List<MemberAddressInfo>();
        }
        public MemberInfo SaveCheckoutAddressInfo(MemberAddressInfo req)
        {
            // eğer yeni ziyaretçi ise
            if (string.IsNullOrWhiteSpace(this.Session.MemberId))
            {
                if(!req.Email.IsEmail())
                    throw new APIException("Invalid email address.");

                // yeni üye kaydı oluşturalım
                Member m = Provider.Database.Read<Member>("Email={0}", req.Email);
                if (m != null)
                    throw new APIException("The email address is registered. Please login before proceeding.",
                                           ErrorTypes.ValidationError, ErrorCodes.ExistingMemberCannotSignUp);

                m = new Member();
                req.CopyPropertiesWithSameName(m);

                if (req.FullName.Contains(" "))
                {
                    while (req.FullName.Contains("  ")) req.FullName = req.FullName.Replace("  ", " ");
                    m.FirstName = req.FullName.Substring(0, req.FullName.IndexOf(' '));
                    m.LastName = req.FullName.Substring(req.FullName.IndexOf(' ') + 1);
                }
                else
                    m.FirstName = req.FullName;

                m.MemberType = MemberTypes.Individual;
                m.State = MemberStates.WaitingEmailConfirmation;
                m.ClientId = ApiClient.ClientId;
                m.Save();

                // yeni üyeye email confirmation mesajı
                m.SendEmailWithPasswordAndConfirmationCode();

                // adress kaydını oluşturalım
                MemberAddress ma = new MemberAddress();
                req.CopyPropertiesWithSameName(ma);
                ma.InvoiceTitle = string.IsNullOrWhiteSpace(ma.InvoiceTitle) ? m.FullName : ma.InvoiceTitle;
                ma.MemberId = m.Id;
                ma.Save();

                // bu adresi üyenin default adresi yapalım
                m.MemberAddressId = ma.Id;
                m.Save();

                // sepetini üye kaydıyla ilişkilendirelim
                var order = Order.GetMemberBasket();
                order.MemberAddressId = ma.Id;
                order.MemberId = m.Id;
                order.Save();

                this.Session.MemberId = m.Id;
                this.Session.Save();

                return m.ToEntityInfo<MemberInfo>();
            }

            // eğer oturum açılmışsa
            {
                // üyede eksik bilgi varsa tamamlayalım
                Member m = this.Session.Member();
                if (string.IsNullOrWhiteSpace(m.FirstName)) // ismi eksikse ekleyelim
                {
                    if (req.FullName!=null && req.FullName.Contains(" "))
                    {
                        while (req.FullName.Contains("  ")) req.FullName = req.FullName.Replace("  ", " ");
                        m.FirstName = req.FullName.Substring(0, req.FullName.IndexOf(' '));
                        m.LastName = req.FullName.Substring(req.FullName.IndexOf(' ') + 1);
                    }
                    else
                        m.FirstName = req.FullName;
                }
                if (string.IsNullOrWhiteSpace(m.CompanyInfo)) // firma adı eksikse ekleyelim
                    m.CompanyInfo = req.InvoiceTitle;
                if (string.IsNullOrWhiteSpace(m.PhoneNumber)) // telefon no eksikse ekleyelim
                    m.PhoneNumber = req.PhoneNumber;
                m.Save();

                // gönderilen adresi insert ya da update edelim
                MemberAddress ma = Provider.Database.Read<MemberAddress>("Id={0}", req.Id) ?? new MemberAddress();
                req.CopyPropertiesWithSameName(ma);
                ma.MemberId = m.Id;
                ma.Save();

                // sepetini adresle ilişkilendirelim
                var order = Order.GetMemberBasket();
                order.MemberAddressId = ma.Id;
                order.MemberId = Session.MemberId;
                order.Save();

                return m.ToEntityInfo<MemberInfo>();
            }
        }

        public OrderInfo GetMemberBasket(ReqEmpty req)
        {
            Order order = Order.GetMemberBasket();

            var res = order.ToOrderInfo();

            if (string.IsNullOrWhiteSpace(order.MemberAddressId) && Provider.CurrentMember!=null)
            {
                order.MemberAddressId = Provider.CurrentMember.MemberAddressId;
                if (!string.IsNullOrWhiteSpace(order.MemberAddressId))
                    order.Save();
            }

            if (!string.IsNullOrWhiteSpace(order.MemberAddressId))
                res.Address = Provider.Database.Read<MemberAddress>("Id={0}", order.MemberAddressId).ToEntityInfo<MemberAddressInfo>();

            return res;
        }
        public OrderInfo AddToOrder(OrderItemInfo orderItem)
        {
            Order order = Order.GetMemberBasket();
            order.AddItem(orderItem);

            return order.ToOrderInfo();
        }
        public OrderInfo RemoveFromOrder(string orderItemId)
        {
            OrderItem entityOrderItem = Provider.Database.Read<OrderItem>("Id={0}", orderItemId);
            if (entityOrderItem == null)
                throw new APIException("No such order item");

            Order order = Order.GetMemberBasket();
            order.RemoveItem(orderItemId);

            if (!string.IsNullOrWhiteSpace(order.CouponItemId))
            {
                try
                {
                    string code = order.CouponItemId;
                    order.CouponItemId = null;
                    order.Discount = 0;
                    order.Save();

                    ApplyCouponCode(code);
                }
                catch
                {
                }
            }

            return GetMemberBasket(null);
        }
        public OrderInfo RemoveAllFromOrder(ReqEmpty req)
        {
            Order order = Order.GetMemberBasket();
            order.CouponItemId = null;
            order.Discount = 0;
            order.RemoveAllItems();

            return order.ToOrderInfo();
        }

        public OrderInfo ApplyCouponCode(string code)
        {
            // coupon code valid?
            if (string.IsNullOrWhiteSpace(code))
                throw new APIException("Coupon code invalid", ErrorTypes.ValidationError);

            // is there a coupon item with this code?
            var couponItem = Provider.Database.Read<CouponItem>("Id={0}", code);
            if (couponItem == null)
                throw new APIException("Coupon code invalid", ErrorTypes.ValidationError);

            // is there a coupon definition about this coupon item?
            var coupon = Provider.Database.Read<Coupon>("Id = {0}", couponItem.CouponId);
            if (coupon == null)
                throw new APIException("Coupon definition not found", ErrorTypes.SystemError);

            // if valid for one year:
            if (coupon.ValidFor1Year && coupon.InsertDate.AddYears(1) < DateTime.Now)
                throw new APIException("Coupon is expired", ErrorTypes.ValidationError);

            // if not valid for one year:
            if (!coupon.ValidFor1Year && (coupon.ValidFrom > DateTime.Now || coupon.ValidTo < DateTime.Now))
                throw new APIException("Coupon is expired or not valid", ErrorTypes.ValidationError);

            // if it is not multiUse and if it is used, throw error
            if (!coupon.MultiUsage && Provider.Database.GetInt("SELECT count(Id) FROM [Order] WHERE CouponItemId={0}", code) > 0)
                throw new APIException("Coupon used before", ErrorTypes.ValidationError);

            // coupon related products
            var productList = Provider.Database.ReadList<CouponProduct>("SELECT * FROM CouponProduct WHERE CouponId = {0}", coupon.Id);
            Order order = Order.GetMemberBasket();

            // order items contains one of coupon related products? Which item is it?
            var item = order.Items.FirstOrDefault(i => productList.Select(cp => cp.ProductId).Contains(i.ProductId));
            if (item == null)
                throw new APIException("Coupon code is not usable for this order", ErrorTypes.ValidationError);

            // coupon is now used:
            order.CouponItemId = code;

            if (coupon.CouponType == CouponTypes.Money)
                order.Discount = coupon.Value;
            else
                order.Discount = coupon.Value * item.Price / 100;

            order.DiscountName = coupon.Name;

            order.CalculateTotalPrice();

            order.Save();

            coupon.UsedNumber++;
            coupon.Save();

            return order.ToOrderInfo();
        }
        public OrderInfo RemoveCouponCode(ReqEmpty req)
        {
            Order order = Order.GetMemberBasket();

            if(string.IsNullOrWhiteSpace(order.CouponItemId))
                throw new APIException("No coupon used for this basket");

            // kuponu serbest bırakalım
            var couponItem = Provider.Database.Read<CouponItem>("Id={0}", order.CouponItemId);
            if (couponItem != null)
            {
                var coupon = Provider.Database.Read<Coupon>("Id = {0}", couponItem.CouponId);
                if (coupon != null)
                {
                    coupon.UsedNumber--;
                    coupon.Save();
                }
            }

            order.CouponItemId = "";
            order.Discount = 0;
            order.DiscountName = "";
            
            order.CalculateTotalPrice();

            order.Save();

            return order.ToOrderInfo();
        }

        #endregion

        #region Order

        public OrderInfo CreateOrderFromBasket(string hash)
        {
            Order order = Order.GetMemberBasket();
            if (order.Items.Count == 0)
                throw new APIException("There is no items in the basket");

            order.PGHash = hash;
            order.State = OrderStates.Order;
            order.OrderDate = DateTime.Now;
            order.InvoiceDate = DateTime.Now;
            order.InvoiceNo = "INV-" + Provider.Database.GetInt("select count(Id) + 1 from [Order]").ToString().PadLeft(6, '0');
            order.DisplayName = order.Items[0].DisplayName;
            order.Save();

            new MemberTransaction
                {
                    MemberId = order.MemberId,
                    RelatedEntityName = "Order",
                    RelatedEntityId = order.Id,
                    Amount = order.TotalPrice,
					TransactionDate = order.OrderDate.Date
                }
                .Save();

            order.AddJobsToQueue();

            return order.ToOrderInfo();
        }

        public List<OrderInfo> GetOrderList(ReqEmpty req)
        {
            if (string.IsNullOrWhiteSpace(Session.MemberId))
                throw new APIException("Access denied");

            return Provider.Database.ReadList<Order>("select * from [Order] where MemberId={0} AND State NOT IN ('Basket','BasketCanceled')", Session.MemberId).ToEntityInfo<OrderInfo>();
        }

        public OrderInfo GetMemberOrder(string orderId)
        {
            return Order.GetMemberOrder(orderId).ToOrderInfo();
        }

        public bool CancelOrderItem(ReqCancelOrderItem req)
        {
            if (req.CancelReason == "0")
            {
                return false;
            }
            else
            {
                OrderItem oi = Provider.Database.Read<OrderItem>("Id={0}", req.OrderItemId);
                var product = oi.Product();

                foreach (var workerType in typeof(BaseWorker).Assembly.GetTypes())
                {
                    if (workerType.IsSubclassOf(typeof(BaseWorker)))
                    {
                        if (workerType.Name.EndsWith(product.ProductTypeId))
                        {
                            var worker = (BaseWorker) Activator.CreateInstance(workerType);
                            worker.CancelOrderItem(req.OrderItemId, req.CancelReason);
                            break;
                        }
                    }
                }

                return true;
            }
        }

        public OrderItemInfo GetOrderItem(string orderItemId)
        {
            if (string.IsNullOrWhiteSpace(Session.MemberId))
                throw new APIException("Access denied");

            return Provider.Database.Read<OrderItem>("Id={0}", orderItemId).ToEntityInfo<OrderItemInfo>();
        }
        #endregion
    }
}