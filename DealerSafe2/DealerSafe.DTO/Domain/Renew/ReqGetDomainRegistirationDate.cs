using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqGetDomainRegistirationDate
    {
        public int DomainId { get; set; }
        public int MemberId { get; set; }
        public string DomainName { get; set; }
    }
}
