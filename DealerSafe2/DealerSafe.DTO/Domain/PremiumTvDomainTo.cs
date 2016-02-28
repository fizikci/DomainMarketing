namespace DealerSafe.DTO.Domain
{
    public class PremiumTvDomainTo
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string PremiumPrice { get; set; }
        public string RenewalPrice { get; set; }
        public string Availability { get; set; }
    }
}
