using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class TransactionStartDLLAPIInfo
    {
        public bool Process { get; set; }
        public string ErrMsg { get; set; }
        public string Appr { get; set; }
        public string RetVal { get; set; }
    }
}
