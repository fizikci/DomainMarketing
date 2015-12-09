using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Response
{
    public class ResGetSearchResults
    {
        public string Id { get; set; }
        public string SellerMemberId { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string CategoryName { get; set; }
        public int BuyItNowPrice { get; set; }
        public int BiggestBid { get; set; }
        public string Language { get; set; }
        public string DescriptionShort { get; set; }
        public int PageRank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public DMAuctionStates Status { get; set; }

    }
}
