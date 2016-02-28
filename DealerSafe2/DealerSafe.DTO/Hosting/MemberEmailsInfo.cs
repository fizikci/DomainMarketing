using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class MemberEmailsInfo
    {
        public int Id { get; set; }
        public int Activity { get; set; }
        public string PostOffice { get; set; }
        public string MailBox { get; set; }
        public long MailBoxSize { get; set; }
        public long MailLimit { get; set; }
    }

}
