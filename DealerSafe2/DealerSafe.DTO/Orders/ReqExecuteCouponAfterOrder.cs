using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqExecuteCouponAfterOrder
    {
        public int CouponId { get; set; }
        public DealerSafe.DTO.enmExecutionStatus ExecutionStatus { get; set; }
    }
}
