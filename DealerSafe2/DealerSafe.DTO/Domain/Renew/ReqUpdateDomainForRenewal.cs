using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqUpdateDomainForRenewal
    {
        public int DomainId { get; set; }
        public int DomainPeriod { get; set; }
        public int Activity { get; set; }
        public decimal DirectiOrderId { get; set; }
        public int DomainProcess { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
