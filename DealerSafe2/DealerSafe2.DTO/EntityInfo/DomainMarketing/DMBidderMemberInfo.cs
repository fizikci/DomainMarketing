using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{

    public class DMBidderMemberInfo : BaseEntityInfo
    {
        //Bid
        public string BidderMemberId { get; set; }
        public int BidValue { get; set; }
        public string BidComments { get; set; }
        public DateTime InsertDate { get; set; }

        //Member
        public string BidderFirstName { get; set; }
        public string BidderLastName { get; set; }
        public string BidderUserName { get; set; }

        //Item
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public int BiggestBid { get; set; }
        public string SellerMemberId { get; set; }


    }
}
