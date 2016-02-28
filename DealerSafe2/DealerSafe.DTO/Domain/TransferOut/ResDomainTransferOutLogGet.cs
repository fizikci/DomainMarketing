using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ResDomainTransferOutLogGet
    {
        public EnmOutTransferDomainProcess enmOutTransferDomainProcess { get; set; }

        public DateTime ProcessDate { get; set; }

        public int MemberId { get; set; }
    }
}
