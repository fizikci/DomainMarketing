using System;
using System.Collections.Generic;
using DealerSafe2.DTO.Enums;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMOfferInfo : BaseEntityInfo
    {

        public string DMItemId { get; set; }

        public string OffererMemberId { get; set; }

        public int OfferValue { get; set; }

        public string OfferComments { get; set; }
    }
}
