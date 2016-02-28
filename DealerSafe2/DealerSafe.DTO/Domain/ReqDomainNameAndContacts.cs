using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainNameAndContacts
    {
        public int DomainId { get; set; }

        public int RegistrContId { get; set; }
        public int AdminContId { get; set; }
        public int TechContId { get; set; }
        public int BillContId { get; set; }
    }
}
