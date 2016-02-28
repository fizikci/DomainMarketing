using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainQuery
    {
        [Description("Comma seperated domain names (ex: isimtescil,google,microsoft)")]
        public string DomainNames { get; set; }
        [Description("Comma seperated domain extensions (ex: .com,.net,.com.tr)")]
        public string TLDs { get; set; }

        [Description("Is this domain query for name surname domains?")]
        public bool NameSurname { get; set; }
        [Description("Is this domain query for utf domains?")]
        public bool IsIDN { get; set; }
        [Description("Is this domain query for summary domains?")]
        public bool IsSummaryDomain { get; set; }
    }
}
