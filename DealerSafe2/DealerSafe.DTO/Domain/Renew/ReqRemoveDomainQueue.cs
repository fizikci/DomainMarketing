using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqRemoveDomainQueue
    {
        public int Id { get; set; }
        public int QueueReportTypeId { get; set; }
        public int TargetId { get; set; }
        public int OperatorId { get; set; }
        public int MemberId { get; set; } 
    }
}
