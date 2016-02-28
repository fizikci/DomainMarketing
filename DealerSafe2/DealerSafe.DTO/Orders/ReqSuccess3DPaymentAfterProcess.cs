using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqSuccess3DPaymentAfterProcess
    {
        public int CreditID { get; set; }
        public double CreditAmount { get; set; }
        public double PaymentAmount  { get; set; }
        public string PostDate { get; set; }
        public string PostTime { get; set; }
    }
}
