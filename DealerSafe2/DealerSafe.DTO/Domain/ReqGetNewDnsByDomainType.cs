using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqGetNewDnsByDomainType
    {
        public int DomainType { get; set; }
        public int DnsType { get; set; }
    }
}
