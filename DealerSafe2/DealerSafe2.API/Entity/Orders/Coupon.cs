using System;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.DTO.Enums;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Orders
{
    public class Coupon : NamedEntity
    {
        public CouponTypes CouponType { get; set; }
        public int Value { get; set; }
        public string Currency { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public int GenerateNumber { get; set; }
        public int UsedNumber { get; set; }
        public bool MultiUsage { get; set; }
        public bool ValidFor1Year { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

        public CouponItem CreateCouponItem()
        {
            var ci = new CouponItem
                {
                    CouponId = this.Id
                };
            ci.Save();
            return ci;
        }

        public override void AfterSave(bool isUpdate)
        {
            base.AfterSave(isUpdate);

            if(!isUpdate)
                for (var i = 0; i < GenerateNumber; i++)
                    CreateCouponItem();
        }
    }
}