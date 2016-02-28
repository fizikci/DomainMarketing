using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqUpdateDomainRenewStatus
    {
        public DomainRenewStatus DomainRenewStatus { get; set; }
        public int DomainRenewRequestId { get; set; }

        public int DomainId { get; set; }
        public int MemberId { get; set; }
    }
}
