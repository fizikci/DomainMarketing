using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateDomainDnsId
    {
        [Description("Id of domain, that's dns's are change")]
        public int DomainId { get; set; }

        [Description("Dns 1")]
        public int DnsId { get; set; }

        [Description("Newly selected dns id")]
        public int SelectedDnsId { get; set; }
    }
}
