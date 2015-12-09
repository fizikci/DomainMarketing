using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMItemInfo : BaseEntityInfo
    {
        // Item Fields
        public DMItemTypes Type { get; set; }
        public string SellerMemberId { get; set; }
        public string SellerFullName { get; set; }
        public string DomainName { get; set; }
        public string DMCategoryId { get; set; }
        public string CategoryName { get; set; }

        public int BuyItNowPrice { get; set; }
        public string LanguageId { get; set; }
        public string Language { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public int MinimumBidPrice { get; set; }
        public int MinimumBidInterval { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool EnableDomainParking { get; set; }
        public bool VisibleInAdNetwork { get; set; }
        public int PageRank { get; set; }
        public string Ownership { get; set; }
        public bool VerificationAsked { get; set; }
        public bool IsPrivateSale { get; set; }
        public string Analytics { get; set; }
        public string AdSense { get; set; }
        public string Alexa { get; set; }

        // Auction Fields
        public DMAuctionStates Status { get; set; }
        public DMAuctionStateReasons StatusReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public DateTime ActualCloseDate { get; set; }
        public int SmallestBid { get; set; }
        public int BiggestBid { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string WinnerMemberId { get; set; }
        public string Comments { get; set; }
    }
}
