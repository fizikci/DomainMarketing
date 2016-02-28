using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqOrderListWithCoupon
    {
        public int FromRowForPage { get; set; }
        public int EndRowForPage { get; set; }
    }
}
