using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqGetCreditPayments
    {
        public int CreditID { get; set; }
        public bool CreditIDSpecified { get; set; }
    }
}
