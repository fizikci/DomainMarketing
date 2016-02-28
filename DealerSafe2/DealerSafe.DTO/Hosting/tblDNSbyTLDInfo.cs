using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class tblDNSbyTLDInfo
    {
        public int Id { get; set; }
        public string TLD { get; set; }
        public string Refresh { get; set; }
        public string Retry { get; set; }
        public string Expire { get; set; }
        public string MinimumTTL { get; set; }
        public string PrimaryNS { get; set; }
        public string SecondaryNS { get; set; }
        public string TertiaryNS { get; set; }
        public string QuaternaryNS { get; set; }
        public string PrimaryNSIP { get; set; }
        public string SecondaryNSIP { get; set; }
        public string TertiaryNSIP { get; set; }
        public string QuaternaryNSIP { get; set; }
        public int isDefault { get; set; }
    }
}
