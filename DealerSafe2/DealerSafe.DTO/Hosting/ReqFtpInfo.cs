namespace DealerSafe.DTO.Hosting
{
    public class ReqFtpInfo
    {
        public ExtraFtpInfo ExtraFtpInfo { get; set; }
        public int MemberId { get; set; }
        public HostingServiceSettings ServiceSettings { get; set; }
        //public int HostingId { get; set; }
        //public int DomainId { get; set; }
    }
}
