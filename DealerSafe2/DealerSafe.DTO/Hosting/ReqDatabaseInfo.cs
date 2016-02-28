namespace DealerSafe.DTO.Hosting
{
    public class ReqDatabaseInfo
    {
        public DatabaseInfo DatabaseInfo { get; set; }
        public int MemberId { get; set; }
        //public int HostingId { get; set; }
        //public int DomainId { get; set; }
        public HostingServiceSettings ServiceSettings { get; set; }
    }
}
