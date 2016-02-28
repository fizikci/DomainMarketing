using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqNSRecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Record Name")]
        public string RecordName { get; set; }

        [Description("Nameserver Name")]
        public string NsServerName { get; set; }

        [Description("Simple dns'in calisacagi server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
