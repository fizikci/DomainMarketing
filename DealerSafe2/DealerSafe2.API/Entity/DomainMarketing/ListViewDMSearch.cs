using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewDMSearch : BaseEntity
    {

        #region DMAuction Fields...

        public string SellerMemberId { get; set; }
        public string DMItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        
        #endregion

        #region DMItem Fields...

        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string CategoryName { get; set; }
        public int BuyItNowPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int PageRank { get; set; }
        
        #endregion
    }

}