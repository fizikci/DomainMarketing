using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqUpdateDomainNameservers
    {
        public string Nameserver1 { get; set; }
        public string Nameserver2 { get; set; }
        public string Nameserver3 { get; set; }
        public string Nameserver4 { get; set; }  
        public int ReferenceId { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; } 
    }
}
