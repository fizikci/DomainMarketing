using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class BankErrorsInfo
    {
        public bool Process { get; set; }
        public List<BankErrorsDetail> BankErrorsList { get; set; }

        public class BankErrorsDetail
        {
            public int Id { get; set; }
            public int BankID { get; set; }
            public string LngBankErrorID { get; set; }
            public string StrErrorDescription { get; set; }
            public bool StolenCard { get; set; }
            public int CardStatus { get; set; }
        }
    }
}
