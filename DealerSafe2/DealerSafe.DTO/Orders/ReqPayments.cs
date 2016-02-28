using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqPayments
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public int Status { get; set; }
    }
}
