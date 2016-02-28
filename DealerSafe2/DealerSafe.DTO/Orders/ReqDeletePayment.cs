using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeletePayment
    {
        public int OrderID { get; set; }
        public bool OrderIDSpecified { get; set; }
        public int PaymentID { get; set; }
        public bool PaymentIDSpecified { get; set; }
        public int MemberID { get; set; }
        public bool MemberIDSpecified { get; set; }
    }
}
