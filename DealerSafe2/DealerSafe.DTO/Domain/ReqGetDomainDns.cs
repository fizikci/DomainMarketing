using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqGetDomainDns
    {
        [Description("Id of domain, that's dns's are change")]
        public int DomainId { get; set; }
    }
}
