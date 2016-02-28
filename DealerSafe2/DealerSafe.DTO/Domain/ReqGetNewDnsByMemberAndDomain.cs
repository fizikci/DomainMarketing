using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqGetNewDnsByMemberAndDomain
    {
        public int MemberId { get; set; }
        public string Domain { get; set; }
    }
}
