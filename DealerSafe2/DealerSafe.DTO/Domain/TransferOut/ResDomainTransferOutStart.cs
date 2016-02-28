using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ResDomainTransferOutStart
    {
        public bool Durum { get; set; }

        public EnmOutTransferDomainStatus Enm { get; set; }
    }
}
