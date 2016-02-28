using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ExistingOrderFirstProcessInfo
    {
        public bool Process { get; set; }
        public bool IsCouponOk { get; set; }
        public bool IsCreditOk { get; set; }
    }
}
