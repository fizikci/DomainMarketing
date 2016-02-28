using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqDomainRenewLogs
    {
        public int InsertUserId { get; set; }
        public int DomainRenewRequestId { get; set; }
        public DomainRenewProcessType Process { get; set; }
        public bool Success { get; set; }
        public int DomainId { get; set; }

        public string Request { get; set; }
        public string Response { get; set; }
    }
}
