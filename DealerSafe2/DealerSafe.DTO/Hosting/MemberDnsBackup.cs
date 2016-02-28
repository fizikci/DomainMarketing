namespace DealerSafe.DTO.Hosting
{
    using System;
    [Serializable]
    public class MemberDnsBackupInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public int HostingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedIp { get; set; }
        public bool Enable { get; set; }
        public string Dns { get; set; }
    }
}
