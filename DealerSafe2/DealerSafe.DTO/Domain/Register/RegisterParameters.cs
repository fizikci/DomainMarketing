namespace DealerSafe.DTO.Domain.Register
{
    public class RegisterParameters
    {
        public int CompanyId { get; set; }
        public string DomainName { get; set; }
        public string ContactId { get; set; }
        public string NameServer1 { get; set; }
        public string NameServer2 { get; set; }
        public string NameServer3 { get; set; }
        public string NameServer4 { get; set; }
        public int DomainPeriod { get; set; }
        public int ReferenceId { get; set; }
        public int DomainId { get; set; }
        public int MemberId { get; set; }
        public string ExtLaunch { get; set; }
    }
}
