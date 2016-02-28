using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqHostUpdate
    {
        [Description("Id of domain this child name server belongs to")]
        public int DomainId { get; set; }

        [Description("Primary Key of child name server")]
        public int NameServerId { get; set; }

        [Description("New name of child name server")]
        public string NewCns { get; set; }

        [Description("New ip of child name server")]
        public string NewIp { get; set; }
    }
}
