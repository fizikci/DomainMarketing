using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferIn
{
    public class ReqDomainTransferInStatusChanged
    {
        public string EnmInTransferDomainStatus { get; set; }

        public int DomainId { get; set; }
    }
}
