using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqRenewRequest
    {
        public int MemberId { get; set; }
        public int OrderId { get; set; }
        public int QueueId { get; set; }
        public int OrderDetailId { get; set; }
        public int DomainId { get; set; }
        public int Quantity { get; set; }
        public int ExtraRenewType { get; set; }
    }
}
