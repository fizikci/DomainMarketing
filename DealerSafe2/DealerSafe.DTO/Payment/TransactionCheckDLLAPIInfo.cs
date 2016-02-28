using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class TransactionCheckDLLAPIInfo
    {
        public bool Process { get; set; }
        public bool IsPayed { get; set; }
        public string ErrMsg { get; set; }
        public string RetVal { get; set; }
        public string Appr { get; set; }
    }
}
