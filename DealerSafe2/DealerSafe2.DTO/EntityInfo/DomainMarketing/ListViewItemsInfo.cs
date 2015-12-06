using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewItemsInfo : BaseEntityInfo
    {
        public int BiggestBid { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public DateTime StartDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public DMAuctionStates Status { get; set; }
        public bool IsPrivateSale { get; set; }
        public bool VerificationAsked { get; set; }
        public bool IsVerified { get; set; }
        public string SellerMemberId { get; set; }
    }
}
