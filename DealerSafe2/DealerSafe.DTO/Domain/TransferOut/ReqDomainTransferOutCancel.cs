using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ReqDomainTransferOutCancel
    {
        public int DomainId { get; set; }

        public int MemberId { get; set; }

        public EnmOutTransferDomainProcess enmOutTransferDomainProcess { get; set; }
    }
}
