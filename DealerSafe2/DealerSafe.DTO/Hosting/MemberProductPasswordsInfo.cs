using System;

namespace DealerSafe.DTO.Hosting
{
    public class MemberProductPasswordsInfo
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int HostingId { get; set; }
        public string DomainName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordType { get; set; }
    }
}
