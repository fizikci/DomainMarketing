using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMAuctionSearchInfo : BaseEntityInfo
    {
        //DMItem Fields...
        public string SellerMemberId { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string CategoryName { get; set; }
        public string Language { get; set; }
        public string DescriptionShort { get; set; }
        public int BuyItNowPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int PageRank { get; set; }

        // Auction Fields...
        public string DMItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
