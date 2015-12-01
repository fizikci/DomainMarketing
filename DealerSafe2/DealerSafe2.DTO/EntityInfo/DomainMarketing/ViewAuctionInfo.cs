using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ViewAuctionInfo : BaseEntityInfo
    {
        public string Type { get; set; }
        public string SellerMemberId { get; set; }
        public string SellerMemberFullName { get; set; }
        public string DomainName { get; set; }
        public int BuyItNowPrice { get; set; }
        public string DMCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string LanguageId { get; set; }
        public string Language { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool EnableDomainParking { get; set; }
        public bool VisibleInAdNetwork { get; set; }
        public int PageRank { get; set; }
        public string Ownership { get; set; }
        public bool IsVerified { get; set; }
        public string Analytics { get; set; }
        public string AdSense { get; set; }
        public string Alexa { get; set; }
        public bool ShowBidList { get; set; }
        public DMAuctionStates Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public string Comments { get; set; }
    }
}
