using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainIdAndProcess
    {
        [Description("id of domain")]
        public int DomainId { get; set; }

        [Description("Domains status")]
        public int Process { get; set; }
    }
}
