using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetRegisterContactByDomainId
    {
        public int DomainId { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }
    }
}
