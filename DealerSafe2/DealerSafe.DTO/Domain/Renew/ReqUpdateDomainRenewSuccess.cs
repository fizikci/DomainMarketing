using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqUpdateDomainRenewSuccess
    {
        public DomainRenewSuccess DomainRenewSuccess { get; set; }
        public int DomainRenewRequestId { get; set; }

        public int DomainId { get; set; }
        public int MemberId { get; set; }
    }
}
