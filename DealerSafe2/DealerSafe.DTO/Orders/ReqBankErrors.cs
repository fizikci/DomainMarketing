using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqBankErrors
    {
        public string BankErrorID { get; set; }
        public bool BankErrrIDSpecified { get; set; }

        public int BankID { get; set; }
        public bool BankIDSpecified { get; set; }
    }
}
