using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferIn
{
    public class ReqDomainTransferInListStaff
    {
        public string State { get; set; }

        public int RowStartIndex { get; set; }

        public int RowEndIndex { get; set; }

        public string AramaType { get; set; }

        public string Arama { get; set; }
    }
}
