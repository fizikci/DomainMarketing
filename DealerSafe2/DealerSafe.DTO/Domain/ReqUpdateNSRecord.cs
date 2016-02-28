using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateNSRecord
    {
        [Description("Name of domain")]
        public string DomainName { get; set; }

        [Description("Name of record")]
        public string RecordName { get; set; }

        [Description("Current Name server")]
        public string OldNs { get; set; }

        [Description("New Name Server")]
        public string NewNs { get; set; }

        [Description("Simpldns'in caliscagi server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
