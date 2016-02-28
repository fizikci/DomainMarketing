namespace DealerSafe.DTO.Hosting
{
    public class ReqDomainInfo
    {
        public DomainInfo DomainInfo { get; set; }
        public int MemberId { get; set; }
        public HostingServiceSettings ServiceSettings { get; set; }
        //public int HostingId { get; set; }
        //public int DomainId { get; set; }
    }
}
