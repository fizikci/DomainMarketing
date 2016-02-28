namespace DealerSafe.DTO.Hosting
{
    using Enums;

    public class ReqAddLog
    {
        public int MemberProductId { get; set; }
        public ProcessTypes ProcessType { get; set; }
        public HostingLogInfo HostingLogDto { get; set; }
    }
}
