using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ModifyRegisterContactTo
    {
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public int DirectiOrderID { get; set; }
        public string ContactId { get; set; }
    }
}
