using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferIn
{
    public class ResDomainTransferInStart
    {

        public bool Durum { get; set; }

        public Tuple<bool, EnmInTransferDomainStatus> enmInTransferDomainStatus1 { get; set; }

        public Tuple<bool, EnmInTransferDomainStatus> enmInTransferDomainStatus2 { get; set; }

        public Tuple<bool, EnmInTransferDomainStatus> enmInTransferDomainStatus3 { get; set; }

    }
}
