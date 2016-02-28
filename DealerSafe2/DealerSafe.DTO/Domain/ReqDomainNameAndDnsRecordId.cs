namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ReqDomainNameAndDnsRecordId
    {
        [Description("name of domain")]
        public string DomainName { get; set; }

        [Description("Dns Record Id")]
        public string DnsRecordId { get; set; }

        [Description("Simple dns'in calisacagi server id")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
