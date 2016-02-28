using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainIdAndStatus
    {
        [Description("id of domain")]
        public int DomainId { get; set; }

        [Description("Domains status")]
        public string Status { get; set; }
    }
}
