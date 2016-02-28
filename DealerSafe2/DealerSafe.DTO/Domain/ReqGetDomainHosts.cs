using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqGetDomainHosts
    {
        [Description("Domain Id of this child name server belongs to")]
        public int DomainId { get; set; }
    }
}
