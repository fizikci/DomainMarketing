using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetDomainRegisterRequestList
    {
        public int Status { get; set; }
        public EnmDomainRegisterProcessType ProcessType { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }

    }
}
