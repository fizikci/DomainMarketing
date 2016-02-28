using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetDomainRegisterRequest
    {
        public int DomainRegisterRequestId { get; set; }
        public EnmDomainRegisterProcessType ProcessType { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }
    }
}
