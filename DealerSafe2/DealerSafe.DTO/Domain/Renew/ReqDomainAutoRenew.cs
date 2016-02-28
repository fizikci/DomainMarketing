using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqDomainAutoRenew
    {
        public DomainRenewRequestInfo DomainRenewRequest { get; set; }
        public int RenewPeriod { get; set; }
        public int QueueId { get; set; }
        public int TargetId { get; set; }
        public int OperatorId { get; set; }
        public int MemberId { get; set; }
    }
}
