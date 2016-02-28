using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ReqGetBank
    {
        public int BankID { get; set; }
        public bool BankIDSpecified { get; set; }
        
        public string BankName { get; set; }
        public bool BankNameSpecified { get; set; }

        public string Branch { get; set; }
        public bool BranchSpecified { get; set; }

        public string AccountType { get; set; }
        public bool AccountTypeSpecified { get; set; }

        public string AccountNumber { get; set; }
        public bool AccountNumberSpecified { get; set; }

        public int Status { get; set; }
        public bool StatusSpecified { get; set; }

        public int Rate { get; set; }
        public bool RateSpecified { get; set; }

        public string AccountNumberOld { get; set; }
        public bool AccountNumberOldSpecified { get; set; }

        public string SwiftCode { get; set; }
        public bool SwiftCodeSpecified { get; set; }

        public int CompanyID { get; set; }
        public bool CompanyIDSpecified { get; set; }
    }
}
