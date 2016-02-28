using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateARecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Old Record Name")]
        public string OldRecordName { get; set; }
        
        [Description("Old Record Info")]
        public string OldIPAddress { get; set; }

        [Description("New Record Name")]
        public string NewRecordName { get; set; }

        [Description("New Ip Address")]
        public string NewIPAddress { get; set; }

        [Description("Simpledns'in calisacagi server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
