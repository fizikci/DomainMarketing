namespace DealerSafe.DTO.Hosting
{
    public class ReqMemberProductPassword
    {
        public int HostingId { get; set; }
        public string DomainName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordType { get; set; }
        public bool IsReseller { get; set; }
    }
}
