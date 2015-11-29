using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Orders
{
    public class CouponItem : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string CouponId { get; set; }

        public Coupon Coupon() { return Provider.ReadEntityWithRequestCache<Coupon>(CouponId); }

    }
}