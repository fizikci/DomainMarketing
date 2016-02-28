using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetCreditsReportInfo
    {
        public bool Process { get; set; }
        public List<CreditsReportListDetail> CreditsReportList { get; set; }

        public class CreditsReportListDetail
        {
            public int CreditID { get; set; }
            public int CreditPaymentID { get; set; }
            public string AdminNotices { get; set; }
            public double CreditAmount { get; set; }
            public string PaymentDate { get; set; }
            public string CreditsPaymentDate { get; set; }
            public int PaymentTypeID { get; set; }
            public string PaymentType { get; set; }
            public string ProcessName { get; set; }
            public int pkProcess { get; set; }
            public double OdenenMiktar { get; set; }
            public int PaymentProcess { get; set; }
        }
    }
}
