using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.MobileBridge
{
    public class ReqDomainHunter
    {
        public string Keyword { get; set; }
        public string DontIncludeNumeric { get; set; }
        public string DontIncludeSeperator { get; set; }
        public int MaxLength { get; set; }
        public bool Extention_COM { get; set; }
        public bool Extention_NET { get; set; }

    }
}
