using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqGetCreditReports
    {
        public int CreditReportID { get; set; }
        public bool CreditReportIDSpecified { get; set; }
        public bool MemberIDSpecified { get; set; }
    }
}
