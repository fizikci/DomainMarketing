using System.ComponentModel;
namespace DealerSafe.DTO.Domain
{
    public class ReqDomainIdAndSecret
    {
        [Description("Primary Key of Domain")]
        public int DomainId { get; set; }

        [Description("Domains secret")]
        public string Secret { get; set; }
    }
}
