using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ReqTransactionStartDLLAPI
    {
        public string TransactionId { get; set; }
        public double HesapOzetitoplamTutarTL { get; set; }
        public string CepNo { get; set; }
        public string pType { get; set; }
    }
}
