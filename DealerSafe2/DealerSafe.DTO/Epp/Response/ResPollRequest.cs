using System;
using System.Collections.Generic;
using System.Linq;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    [Serializable]
    public class ResPollRequest
    {

        public int Count { get; set; }

        public string Message { get; set; }

        public string MessageId { get; set; }

        public DateTime QueueDate { get; set; }

        public string Details { get; set; }
    }
}