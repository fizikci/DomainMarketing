using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqUpdateDomainQueue
    {
        public int Id { get; set; }
        public int QueueProcessTypeId { get; set; }
        public int QueueReportTypeId { get; set; }
        public int QueueProcessStatus { get; set; }
        public int MemberId { get; set; }
        public int TargetId { get; set; }
    }
}
