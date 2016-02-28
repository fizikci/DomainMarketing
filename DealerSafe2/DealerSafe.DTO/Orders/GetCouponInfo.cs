using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetCouponInfo
    {
        public bool Process { get; set; }
        public List<CouponDetail> CouponDetails { get; set; }

        public class CouponDetail
        {
            public int RecId { get; set; }
            public string RecDate { get; set; }
            public int RecCreater { get; set; }
            public string CouponCode { get; set; }
            public int CouponType { get; set; }
            public decimal CouponPercentageValue { get; set; }
            public decimal CouponValue { get; set; }
            public string CouponCurrency { get; set; }
            public string ValidFrom { get; set; }
            public string ValidTo { get; set; }
            public int CouponUsageNumber { get; set; }
            public int CouponUsedNumber { get; set; }
            public bool CouponMultiUsage { get; set; }
            public int ExecutionStatus { get; set; }
            public string ExecutedDate { get; set; }
            public int ExecutedForOrder { get; set; }
            public int ExecutedForMember { get; set; }
            public string ProductRelation { get; set; }
            public int MemberId { get; set; }
            public double CouponUnexpendedValue { get; set; }
            public int FirstYearCurrently { get; set; }
            public string CouponNickName { get; set; }
        }
    }
}
