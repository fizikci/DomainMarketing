using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Epp.Protocol.Rgp;

namespace DealerSafe.DTO.Epp.Response
{
    public class ResDomainUpdate
    {
        public respDataType ExtRgp { get; set; }

        public string DirectiActionStatusDescription { get; set; }

        public string NicTrActionStatusDescription { get; set; }
    }
}
