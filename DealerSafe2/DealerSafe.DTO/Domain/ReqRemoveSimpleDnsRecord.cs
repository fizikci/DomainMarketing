using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqRemoveSimpleDnsRecord
    {
        [Description("Domain name")]
        public string DomainName { get; set; }

        [Description("Record name")]
        public string RecordName { get; set; }

        [Description("Record Type")]
        public string RecordType { get; set; }

        [Description("Record Data")]
        public string[] RecordData { get; set; }

        [Description("Simple Dns'in calisacagi server id")]
        public int? ServerId { get; set; }

        [Description("Power Dns mi")]
        public bool? isPower { get; set; }
    }
}
