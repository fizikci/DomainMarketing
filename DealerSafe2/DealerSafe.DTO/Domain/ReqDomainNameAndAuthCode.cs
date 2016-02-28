using System.ComponentModel;
namespace DealerSafe.DTO.Domain
{
    public class ReqDomainNameAndAuthCode
    {
        [Description("Name of domain")]
        public string DomainName { get; set; }

        [Description("Domains Auth Code")]
        public string AuthCode { get; set; }
    }
}
