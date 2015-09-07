using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewAuctionsInfo : BaseEntityInfo
    {
        public string Id { get; set; }
        public int BiggestBid {get; set;}
        public string Type {get; set;}
        public string DomainName {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime PlannedCloseDate {get; set;}
        public int BuyItNowPrice {get; set;}


    }
}
