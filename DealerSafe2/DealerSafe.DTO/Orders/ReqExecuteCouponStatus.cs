using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqExecuteCouponStatus
    {
        public string CouponCode { get; set; }
        public enmExecutionStatus ExecutionStatus { get; set; }
        public int ExecutedOrderId { get; set; }
        public string ExecutedDate { get; set; }
        public double CouponUnexpendedValue { get; set; }
        public enmCoupontype CouponType { get; set; }
        public double CouponValue { get; set; }
    }
}
