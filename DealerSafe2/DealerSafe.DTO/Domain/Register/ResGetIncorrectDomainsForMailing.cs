using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Register
{
    public class ResGetIncorrectDomainsForMailing
    {
        public string DomainName { get; set; }
        public string ExtensionName { get; set; }
        public string MemberEmail { get; set; }
    }
}
