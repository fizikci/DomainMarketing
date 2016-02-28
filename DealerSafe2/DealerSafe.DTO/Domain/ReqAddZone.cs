using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqAddZone
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Primary Name server")]
        public string PrimaryNameServer { get; set; }

        [Description("Host master mail")]
        public string HostMasterMail { get; set; }

        [Description("Default TTL value")]
        public int DefaultTtl { get; set; }

        [Description("Minimum TTL value")]
        public int MinimumTtl { get; set; }

        [Description("Zone group id")]
        public int ZoneGroupId { get; set; }

        [Description("Simple Dns server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
