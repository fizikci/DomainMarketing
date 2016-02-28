namespace DealerSafe.DTO.Hosting
{
    using System;

    [Serializable]
    public class MemberProductDomainsInfo
    {
        public int Id { get; set; }
        public int HostingID { get; set; }
        public string DomainName { get; set; }
        public string DomainUser { get; set; }
        public DateTime RecDate { get; set; }
        public bool DomainOwnerIT { get; set; }
        public int? MembersDNSID { get; set; }
        public bool TempDomain { get; set; }
        public string Pass { get; set; }
    }
}
