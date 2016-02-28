namespace DealerSafe.DTO.Common
{
    public class ReqSendMail
    {
        public string FromEmailAddres { get; set; }
        public string MemberEmail { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}
