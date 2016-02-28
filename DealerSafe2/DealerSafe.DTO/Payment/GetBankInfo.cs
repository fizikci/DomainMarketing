using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class GetBankInfo
    {
        public bool Process { get; set; }
        public List<BankDetail> Banks { get; set; }
        public class BankDetail
        {
            public int BankID { get; set; }
            public string Bank { get; set; }
            public string Branch { get; set; }
            public string AccountType { get; set; }
            public string AccountNumber { get; set; }
            public int Status { get; set; }
            public int Rate { get; set; }
            public string AccountNumberOld { get; set; }
            public string SwiftCode { get; set; }
            public int CompanyID { get; set; }
        }
    }
}
