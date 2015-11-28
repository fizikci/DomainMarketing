using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    [TableDetail(ViewSQL= @"
        CREATE VIEW [ListViewDMBidderMember] 
        AS
        SELECT
            B.[Id] AS BidId,
            B.[DMAuctionId],
            B.[BidderMemberId],
            B.[BidValue],
            B.[BidComments],
            B.[InsertDate],
            B.[IsDeleted],
            M.[Id],
            M.[FirstName],
            M.[LastName],
            M.[UserName],
            I.[DomainName],
            I.[Type],
            A.[BiggestBid]
            I.[SellerMemberId]
        FROM DMBid AS B
        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
        INNER JOIN DMAuction AS A ON A.Id = B.DMAuctionId
        INNER JOIN DMItem AS I ON I.Id = A.DMItemId
    ")]
    public class ListViewDMBidderMember : BaseEntity
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
        public string SellerMemberId { get; set; }

        #endregion

        #region membersection

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("firstname of user")]
        public string FirstName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("lsatname of user")]
        public string LastName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 64), Description("username of user")]
        public string UserName { get; set; }

        #endregion
    }
}