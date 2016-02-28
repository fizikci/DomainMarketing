namespace DealerSafe.DTO.Hosting
{
    public class ReqHostingInfo
    {
        //public int HostingId { get; set; }
        //public int DomainId { get; set; }
        public HostingServiceSettings ServiceSettings { get; set; }
        public int MemberId { get; set; }
    }
}
