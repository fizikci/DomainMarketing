using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqTxtRecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Record Name")]
        public string RecordName { get; set; }

        [Description("Record Data")]
        public string[] RecordData { get; set; }

        [Description("Simpledns'in calisacagi server")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
