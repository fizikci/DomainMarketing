using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewDMBidderMember:BaseEntity
    {

        #region bidsection

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction")]
        public string DMAuctionId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 10)]
        public DMItemTypes Type { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the bid")]
        public string BidId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("biddersmemberid")]
        public string BidderMemberId { get; set; }

        [Description("price offered by the bidder")]
        public int BidValue { get; set; }

        [Description("highest price ever bidded")]
        public int BiggestBid { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("comments")]
        public string BidComments { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 70), Description("name of the item")]
        public string DomainName { get; set; }

        [Description("starting date of the auction")]
        public DateTime InsertDate { get; set; }

        [Description("isdeleted")]
        public bool IsDeleted { get; set; }

        #endregion

        #region membersection

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the requesting member")]
        public string MemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("firstname of user")]
        public string FirstName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("lsatname of user")]
        public string LastName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 64), Description("username of user")]
        public string UserName { get; set; }

        #endregion
    }
}