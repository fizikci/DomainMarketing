using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Products;

namespace DealerSafe2.API.Entity.Orders
{
    public class CouponProduct : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string CouponId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ProductId { get; set; }

        public Coupon Coupon() { return Provider.ReadEntityWithRequestCache<Coupon>(CouponId); }
        public Product Product() { return Provider.ReadEntityWithRequestCache<Product>(ProductId); }

    }

    public class ListViewCouponProduct : CouponProduct
    {
        public string CouponName { get; set; }
        public string ProductName { get; set; }
    }
}