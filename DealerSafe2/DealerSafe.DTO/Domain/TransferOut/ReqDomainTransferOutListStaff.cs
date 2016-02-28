using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ReqDomainTransferOutListStaff
    {
        public List<EnmOutTransferDomainProcess> ListenmOutTransferDomainProcess { get; set; }

        public int RowStartIndex { get; set; }

        public int RowEndIndex { get; set; }

        public string AramaType { get; set; }

        public string Arama { get; set; }
    }
}
