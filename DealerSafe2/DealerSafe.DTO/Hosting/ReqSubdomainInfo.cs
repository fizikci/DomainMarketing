namespace DealerSafe.DTO.Hosting
{
    public class ReqSubdomainInfo
    {
        public SubdomainInfo SubdomainInfo { get; set; }
        public int MemberId { get; set; }
        //public int HostingId { get; set; }
        //public int DomainId { get; set; }
        public HostingServiceSettings ServiceSettings { get; set; }
    }
}
