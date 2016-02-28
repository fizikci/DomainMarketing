using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqExecuteCoupon
    {
        public int CouponID { get; set; }
        public enmExecutionStatus ExecutionStatus { get; set; }
    }
}
