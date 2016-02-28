using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqGetDomainRenewRequests
    {
        public DomainRenewStatus DomainRenewStatus { get; set; }
        public DomainRenewSuccess DomainRenewSuccess { get; set; }
        public EnmExtraRenewType ExtraRenewType { get; set; }
        public int DomainId { get; set; }
    }
}
