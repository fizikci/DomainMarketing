using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateMXRecord
    {
        [Description("Name of domain")]
        public string DomainName { get; set; }

        [Description("Name of old record")]
        public string OldRecordName { get; set; }

        [Description("Old Priority value")]
        public string OldPriority { get; set; }

        [Description("Old mail server")]
        public string OldMailServer { get; set; }

        [Description("New Priority")]
        public string NewPriority { get; set; }

        [Description("New Mail server")]
        public string NewMailServer { get; set; }

        [Description("Simpledns'in calisacagi server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
