using System;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqSaveDomainRenewRequest
    {
        public int Status { get; set; }
        public DateTime RegDateInOur { get; set; }
        public DateTime RegDateInRegistry { get; set; }
        public DateTime ExpDateInOur { get; set; }
        public DateTime ExpDateInRegistry { get; set; }
        public DateTime NewExpDateInOur { get; set; }
        public DateTime NewExpDateInRegistry { get; set; }
        public int DomainId { get; set; }
        public int OrderDetailId { get; set; }
        public string DomainStatus { get; set; }
        public bool IsSuccess { get; set; }
        public int ExtraRenewType { get; set; }
    }
}
