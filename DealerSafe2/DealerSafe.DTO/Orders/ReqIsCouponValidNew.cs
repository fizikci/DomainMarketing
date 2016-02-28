using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqIsCouponValidNew
    {
        [Description("Coupon code of the member")]
        public string CouponCode { get; set; }
    }
}
