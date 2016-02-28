using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqMXRecord
    {
        [Description("Domain Name")]
        public string DomainName { get; set; }
        
        [Description("Record Name")]
        public string RecordName { get; set; }

        [Description("Priority")]
        public string Priority { get; set; }

        [Description("Mail Server")]
        public string MailServer { get; set; }

        [Description("Simple dns'in calisacagi server id")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
