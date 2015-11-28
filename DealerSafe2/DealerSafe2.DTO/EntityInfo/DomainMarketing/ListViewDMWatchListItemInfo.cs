using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewDMWatchListItemInfo : BaseEntityInfo
    {
        public string MemberId { get; set; }
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public DMItemStates Status { get; set; }
        public bool IsPrivateSales { get; set; }
        public string Ownership { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
