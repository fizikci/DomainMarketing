namespace DealerSafe.DTO.Hosting
{
    public class ReqWriteDns
    {
        public string DomainName { get; set; }
        public int MailServerId { get; set; }
        public int ServerId { get; set; }
        public int MemberProductId { get; set; }
    }
}
