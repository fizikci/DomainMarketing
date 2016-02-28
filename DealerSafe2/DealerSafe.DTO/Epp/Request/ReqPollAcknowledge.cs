using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;

namespace DealerSafe.DTO.Epp.Request
{
    [Serializable]
    public class ReqPollAcknowledge : ReqBase
    {
        public string DomainName { get; set; }
        public string ClientTranId { get; set; }
        public string MessageId { get; set; }
    }
}