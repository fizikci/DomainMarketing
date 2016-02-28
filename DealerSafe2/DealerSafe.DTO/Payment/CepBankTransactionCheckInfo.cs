using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class CepBankTransactionCheckInfo
    {
        public string ResponseText { get; set; }
        public bool IsPayed { get; set; }
        public string ErrorMessage { get; set; }
        public string Appr { get; set; }
    }
}
