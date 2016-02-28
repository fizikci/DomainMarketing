using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqRemoveSrvRecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Record Name")]
        public string RecordName { get; set; }

        [Description("Current Priority")]
        public string CurrentPriority { get; set; }

        [Description("Current Weight")]
        public string CurrentWeight { get; set; }

        [Description("Current Mx Port")]
        public string CurrentMxPort { get; set; }

        [Description("Current Host")]
        public string CurrentHost { get; set; }

        [Description("Simpledns'in calisacagi server id")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
