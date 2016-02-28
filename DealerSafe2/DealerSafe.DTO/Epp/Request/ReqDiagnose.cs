using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Enums;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;

namespace DealerSafe.DTO.Epp.Request
{
    [Serializable]
    public class ReqDiagnose : ReqBase
    {
        public EppQueueCommands Command { get; set; }

        public string DomainName { get; set; }
    }
}