using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Epp.Response
{
    public class ResDomainTransferRequest
    {
        public string Status { get; set; }
        public int DirectiOrderId { get; set; }
        public string DirectiActionStatusDesc { get; set; }
    }
}
