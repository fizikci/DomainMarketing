using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Common
{
    public class ReqCrossBuyingSelection
    {
        public int BasketId { get; set; }

        public string IpAdress { get; set; }

        public EnmCampingCrossBuyingMemberOfferSelection SelectionType { get; set; }

    }
}
