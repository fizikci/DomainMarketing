using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ResGetDomainMove
    {
        public int DomainId { get; set; }
        public int MoveId { get; set; }
        public string PreOwnerName { get; set; }
        public int PreMemberId { get; set; }
        public string Domain { get; set; }
        public DateTime InitDate { get; set; }
        public bool Action { get; set; }
        public string RegisterCompany { get; set; }
    }
}
