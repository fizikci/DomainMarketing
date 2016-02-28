using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class OrdersForCreditManagementPageInfo
    {
        public bool Process { get; set; }
        public int CountOfCreditReport { get; set; }
        public List<ListOfCreditReport> CreditReportList { get; set; }

        public class ListOfCreditReport
        {
            public int Row { get; set; }
            public int CreditReportsID { get; set; }
            public int OrderID { get; set; }
            public double EskiMiktar { get; set; }
            public double CekilenMiktar { get; set; }
            public string OrderDate { get; set; }
            public int intCreditReportType { get; set; }
        }
    }
}
