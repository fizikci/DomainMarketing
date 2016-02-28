using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqUpdateExtLaunch
    {
        public EnmDomainRegisterType RegisterType { get; set; }
        public int ReferenceId { get; set; }
        public string ExtLaunch { get; set; }
    }
}
