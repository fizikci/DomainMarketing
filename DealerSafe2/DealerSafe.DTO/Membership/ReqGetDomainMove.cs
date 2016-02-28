using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqDomainMove
    {
        public int DomainId { get; set; }
        public int MoveId { get; set; }
        public int NextMemberId { get; set; }
        public int PreMemberId { get; set; }
        public string DomainSecret { get; set; }
        public string DomainName { get; set; }
        public string Ip { get; set; }
    }

}
