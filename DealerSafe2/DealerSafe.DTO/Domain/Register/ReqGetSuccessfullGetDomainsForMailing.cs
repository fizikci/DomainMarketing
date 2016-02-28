using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetSuccessfullDomainsForMailing
    {
        public EnmDomainRegisterType RegisterType { get; set; }
        public int ExtensionId { get; set; }
    }
}
