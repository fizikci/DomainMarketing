using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqSetMemberDnsListInfo
    {
        [Description("Id of domain, that's dns's are change")]
        public int DnsId { get; set; }

        [Description("1: DefaultDns, 2: SpecificDns")]
        public int DnsType { get; set; }
    }
}
