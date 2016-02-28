using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqARecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Record Name")]
        public string RecordName { get; set; }

        [Description("Ip Adress")]
        public string IpAdress { get; set; }

        [Description("Simple Dns server id'si")]
        public int? ServerId { get; set; }
        
        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
