using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateMemberDnsList
    {
        [Description("Id of dns")]
        public int DnsId { get; set; }

        [Description("Dns 1")]
        public string Dns1 { get; set; }

        [Description("Dns 2")]
        public string Dns2 { get; set; }

        [Description("Dns 3")]
        public string Dns3 { get; set; }

        [Description("Dns 4")]
        public string Dns4 { get; set; }
    }
}
