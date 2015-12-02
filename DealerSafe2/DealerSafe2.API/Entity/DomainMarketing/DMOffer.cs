using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMOffer : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction, fk referencing auction table")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the bidder, fk referencing member table")]
        public string OffererMemberId { get; set; }

        [Description("price offered by the bidder")]
        public int OfferValue { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("comments")]
        public string OfferComments { get; set; }
        public DateTime ReviewedAt { get; set; }
        public DMOfferStatus Status { get; set; }

    }
}