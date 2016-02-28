using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqPaymentFail
    {
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string TotalAmount { get; set; }
        public string OrderID { get; set; }
        public string Notice { get; set; }
    }
}
