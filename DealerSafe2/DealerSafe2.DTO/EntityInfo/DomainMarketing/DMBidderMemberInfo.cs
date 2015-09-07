using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{

    public class DMBidderMemberInfo : BaseEntityInfo
    {
        public string DMAuctionId { get; set; }
        public int BiggestBid { get; set; }
        public DMItemTypes Type { get; set; }
        public string BidId { get; set; }
        public string BidderMemberId { get; set; }
        public int BidValue { get; set; }
        public string BidComments { get; set; }
        public string DomainName { get; set; }
        public DateTime InsertDate { get; set; }
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

    }
}
