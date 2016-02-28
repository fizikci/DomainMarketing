using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums.BCIT;

namespace DealerSafe.DTO.Domain
{
    public class ReqRemoveFromQueue
    {
        public int QueueId { get; set; }
        public int DomainId { get; set; }
        public string RegisterCompany { get; set; }
        public int OperatorId { get; set; }
        public int MemberId { get; set; }
        public bool MemberApproved { get; set; }

    }
}
