using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateCNameRecord
    {
        [Description("Name of domain")]
        public string DomainName { get; set; }

        [Description("Name of record")]
        public string RecordName { get; set; }

        [Description("Current Record")]
        public string OldRecordData { get; set; }

        [Description("New Record")]
        public string NewRecordData { get; set; }

        [Description("Simple dns'in calisacagi server id'si")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
