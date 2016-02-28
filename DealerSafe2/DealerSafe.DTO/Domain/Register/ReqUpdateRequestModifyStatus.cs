using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqUpdateDomainRegisterProcessType
    {
        public int ReferenceId { get; set; }
        public EnmDomainRegisterProcessType ProcessType { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }
        public int Status { get; set; }
    }
}
