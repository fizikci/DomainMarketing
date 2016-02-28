using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainAndContacts
    {
        public string DomainName { get; set; }
        public string OwnerId { get; set; }
        public string AdminId { get; set; }
        public string TechId { get; set; }
        public string ContactId { get; set; }
    }
}
