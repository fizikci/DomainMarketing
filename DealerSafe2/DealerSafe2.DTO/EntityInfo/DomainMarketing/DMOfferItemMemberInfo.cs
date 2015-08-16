using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{

    public class DMOfferItemMemberInfo : BaseEntityInfo
    {

        public string OffererMemberId { get; set; }

        public string DMItemId { get; set; }

        public string DMOfferId { get; set; }

        public string DMAuctionId { get; set; }

        public string MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string OffererMemberFirstName { get; set; }

        public string OffererMemberLastName { get; set; }

        public int OfferValue { get; set; }

        public int BiggestBid { get; set; }

        public int BuyItNowPrice { get; set; }

        public DMItemTypes Type { get; set; }

        public string DomainName { get; set; }
    }
}
