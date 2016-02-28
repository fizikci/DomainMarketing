using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetCreditReportsInfo
    {
        public bool Process { get; set; }
        public List<CreditReportDetail> CreditReports { get; set; }
        public class CreditReportDetail
        {
            public int ID { get; set; }
            public int MemberID { get; set; }
            public int OrderID { get; set; }
            public double EskiMiktar { get; set; }
            public double CekilenMiktar { get; set; }
            public string PriceType { get; set; }
            public string ReportNotice { get; set; }
            public int CreditReportType { get; set; }
            public int ReportTypeID { get; set; }
            public string Date { get; set; }
        }
    }
}
