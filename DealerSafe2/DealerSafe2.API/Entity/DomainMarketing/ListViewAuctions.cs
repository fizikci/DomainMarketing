using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewAuctions : BaseEntity
    {
        public string Id { get; set; }
        public int BiggestBid { get; set; }
        public string Type { get; set; }
        public string DomainName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedCloseDate { get; set; }
        public int BuyItNowPrice { get; set; }


    }
}