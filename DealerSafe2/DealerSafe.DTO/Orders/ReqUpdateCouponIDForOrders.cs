using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqUpdateCouponIDForOrders
    {
        public int OrderID { get; set; }
        public int CouponID { get; set; }
        public bool CouponIsNull { get; set; }
    }
}
