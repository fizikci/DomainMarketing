using System;
using System.Collections.Generic;

namespace DealerSafe.DTO.MobileBridge
{
    public class RespDomainHunter
    {
        public string Domain { get; set; }
        public string Expiry { get; set; }
        public string Price { get; set; }
    }

    public class ResDomainHunter
    {
        public string Domain { get; set; }
        public DateTime Expiry { get; set; }
        public decimal Price { get; set; }
    }

    public class ReqDomainHunter
    {
        public string Keywords { get; set; }
        public EnmKeywordTypes KeywordType { get; set; }
        public DateTime ExpiryDateStarts { get; set; }
        public DateTime ExpiryDateEnds { get; set; }
        public List<string> DomainExtensions { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeHyphens { get; set; }
        public string SortBy { get; set; }
        public int CharLength { get; set; }
    }

    public enum EnmKeywordTypes
    {
        Contains = 1,
        StartsWith = 2,
        EndsWith = 3,
    }
}
