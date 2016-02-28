using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateDomainDns
    {
        [Description("Id of domain, that's dns's are change")]
        public int DomainId { get; set; }

        [Description("Dns 1")]
        public string DomainDns1 { get; set; }

        [Description("Dns 2")]
        public string DomainDns2 { get; set; }

        [Description("Dns 3")]
        public string DomainDns3 { get; set; }

        [Description("Dns 4")]
        public string DomainDns4 { get; set; }
    }
}
