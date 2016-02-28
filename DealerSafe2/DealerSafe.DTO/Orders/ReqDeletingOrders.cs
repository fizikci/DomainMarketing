using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeletingOrders
    {
        public int MemberID { get; set; }
        public bool MemberIDSpecified { get; set; }

        public int Process { get; set; }
        public bool ProcessSpecified { get; set; }

        public int IsCustomerDebit { get; set; }
        public bool IsCustomerDebitSpecified { get; set; }

        public string MaxOrderDate { get; set; }
        public bool MaxOrderDateSpecified { get; set; }
    }
}
