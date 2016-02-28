using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class ReqGetDomainRegisterRequestWithReferenceId
    {
        public int ReferenceId { get; set; }
        public EnmDomainRegisterProcessType ProcessType { get; set; }
        public EnmDomainRegisterType RegisterType { get; set; }
    }
}
