using System;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqDomainRegisterRequest
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime TldActivityDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string DomainName { get; set; }
        public int DomainPeriod { get; set; }
        public int CompanyId { get; set; }
        public string Nameserver1 { get; set; }
        public string Nameserver2 { get; set; }
        public string Nameserver3 { get; set; }
        public string Nameserver4 { get; set; }
        public string ContactId { get; set; }
        public int ProcessType { get; set; }
        public int ReferenceId { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }
        public bool IsModify { get; set; }
        public bool WhoIsProtection { get; set; }
        public string ExtLaunch { get; set; }
    }
}
