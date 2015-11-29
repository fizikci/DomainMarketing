using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMBid : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction, fk referencing auction table")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the bidder, fk referencing member table")]
        public string BidderMemberId { get; set; }

        [Description("price offered by the bidder")]
        public int BidValue { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("comments")]
        public string BidComments { get; set; }

    }
}