using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ResGetDomainRenewCheckList
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public int DomainId { get; set; }
        public int RenewMode { get; set; }
        public DateTime RenewalDate { get; set; }
        public int DomainRenewRequestId { get; set; }
    }
}
