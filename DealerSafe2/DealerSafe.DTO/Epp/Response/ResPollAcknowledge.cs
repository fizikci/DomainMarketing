using System;
using System.Collections.Generic;
using System.Linq;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    [Serializable]
    public class ResPollAcknowledge
    {
        public int Count { get; set; }

        public string MessageId { get; set; }
    }
}