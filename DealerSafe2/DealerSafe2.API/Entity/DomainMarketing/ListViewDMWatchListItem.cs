using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewDMWatchListItem : BaseEntity
    {
        public string MemberId { get; set; }
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public DMItemStates Status { get; set; }
        public bool IsPrivateSales { get; set; }
        public bool IsDeleted { get; set; }
        public string Ownership { get; set; }
    }
}