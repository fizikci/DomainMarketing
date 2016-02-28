using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqUpdateCreditReportsIDForOrders
    {
        public int OrderID { get; set; }
        public int CreditReportsID { get; set; }
        public bool CreditReportsIDIsNull { get; set; }
    }
}
