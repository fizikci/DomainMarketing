using System.ComponentModel;
namespace DealerSafe.DTO.Domain
{
    public class ReqDirectiOrderIdAndCode
    {
        [Description("Directi Order Id")]
        public string DirectiOrderId { get; set; }

        [Description("Association code")]
        public string Code { get; set; }

        public string DomainName { get; set; }
    }
}
