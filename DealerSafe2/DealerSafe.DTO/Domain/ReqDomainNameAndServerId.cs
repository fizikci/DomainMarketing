using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainNameAndServerId
    {
        public string DomainName { get; set; }

        public int? ServerId { get; set; }
        public bool? isPower { get; set; }
    }
}
