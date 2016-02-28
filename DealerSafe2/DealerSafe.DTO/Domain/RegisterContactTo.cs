using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class RegisterContactTo
    {
        public DomainContactsTo DomainContact { get; set; }
        public string DomainName { get; set; }
        public int DirectiCustomerId { get; set; }
    }
}
