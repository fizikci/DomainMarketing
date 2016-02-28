using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Register
{
    public class DomainRegisterCompletedRequestsInfo
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime TldActivityDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DomainId { get; set; }
        public DateTime DomainCreationDate { get; set; }
        public DateTime DomainExpirationDate { get; set; }
        public string DomainName { get; set; }
        public int DomainPeriod { get; set; }
        public int CompanyId { get; set; }
        public int WhoisProtection { get; set; }
        public string Nameserver1 { get; set; }
        public string Nameserver2 { get; set; }
        public string Nameserver3 { get; set; }
        public string Nameserver4 { get; set; }
        public string ContactId { get; set; }
        public int ProcessType { get; set; }
        public int ReferenceId { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
