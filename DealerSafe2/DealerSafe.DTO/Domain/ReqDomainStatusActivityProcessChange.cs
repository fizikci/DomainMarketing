using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainStatusActivityProcessChange
    {
        public int DomainId { get; set; }
        public EnmMembersDNSStatus enmMembersDNSStatus { get; set; }
        public EnmMembersDNSActivity enmMembersDNSActivity { get; set; }
        public EnmMembersDNSDomainProcess enmMembersDNSDomainProcess { get; set; }
    }
}
