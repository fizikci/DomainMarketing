using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqCQueueCheckDomain
    {
        public int QueueProcessTypeId { get; set; }
        public int QueueReportTypeId { get; set; }
        public int DomainId { get; set; }
        public int OrderId { get; set; }
    }
}
