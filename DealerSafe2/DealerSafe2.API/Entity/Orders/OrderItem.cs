using System;
using System.Collections.Generic;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Orders
{
    public class OrderItem : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string OrderId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int OrderNo { get; set; }
        public string DisplayName { get; set; }
        [ColumnDetail(Length = 12)]
        public string ProductPriceId { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public int ExchangeRate { get; set; }
        public int Tax { get; set; }
        public string ParentOrderItemId { get; set; }

        public Order Order() { return Provider.ReadEntityWithRequestCache<Order>(OrderId); }
        public Product Product() { return Provider.ReadEntityWithRequestCache<Product>(ProductId); }
        public ProductPrice ProductPrice() { return Provider.ReadEntityWithRequestCache<ProductPrice>(ProductPriceId); }


        public List<OrderItem> Items { get; set; }

        public override void Delete()
        {
            Provider.Database.Execute(() =>
            {
                foreach (var job in Provider.Database.ReadList<Job>("select * from Job where RelatedEntityName='OrderItem' AND RelatedEntityId={0}", this.Id))
                {
                    if (!(job.State == JobStates.Done || job.State == JobStates.Failed))
                        job.State = JobStates.Canceled;
                    job.Save();
                }

                foreach (var childOrderItem in Provider.Database.ReadList<OrderItem>("select * from OrderItem where ParentOrderItemId={0}", this.Id))
                    childOrderItem.Delete();

                if (this.Order().State == OrderStates.Basket)
                    Provider.Database.ExecuteNonQuery("delete from OrderItem where Id = {0}", this.Id);
                else
                    base.Delete();
            });
        }


        public override void Save()
        {
            if (this.Amount == 0)
            {
                var orderItemInfo = this.ToEntityInfo<OrderItemInfo>();
                if (orderItemInfo.Amount == 0) orderItemInfo.Amount = ProductPrice().Amount;
                Order().AddItem(orderItemInfo);
            }
            else
            {
                base.Save();
            }
        }

        public void Cancel()
        {
            Provider.Database.Execute(() =>
                {
                    this.Delete();

                    var o = Orders.Order.GetMemberOrder(this.OrderId);
                    o.Items.RemoveAll(oi => oi.Id == this.Id);

                    o.CalculateTotalPrice();
                    o.Save();

                    //TODO: ya coupon'un uygulandığı satır siliniyorsa!!!???

                    o.Member().CreditBalance += this.Price;
                    o.Member().Save();

                    var cancelJob = Provider.Database.Read<Job>("RelatedEntityId = {0} AND RelatedEntityName='OrderItem' AND Command={1}", this.Id, JobCommands.CancelRefundReq.ToString());
                    if (cancelJob != null)
                    {
                        cancelJob.State = JobStates.Done;
                        cancelJob.Save();
                    }
                });
        }
    }


    public class ListViewOrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int OrderNo { get; set; }
        public string DisplayName { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public int ExchangeRate { get; set; }
        public int Tax { get; set; }
        public string ProductPriceId { get; set; }
        public string ParentOrderItemId { get; set; }
    }

    public class ViewOrderItem : OrderItem
    {
        public string ProductName { get; set; }
    }
}