using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqUpdateContact
    {
        public int ReferenceId { get; set; }
        public string ContactId { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; } 
    }
}
