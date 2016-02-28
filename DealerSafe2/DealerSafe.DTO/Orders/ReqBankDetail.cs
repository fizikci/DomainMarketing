using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqBankDetail
    {
        [Description("Number of the bank")]
        public int BankID { get; set; }

        [Description("Number of the sub bank")]
        public int SubBankID { get; set; }
    }
}
