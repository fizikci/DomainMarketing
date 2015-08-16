using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewOfferItemMember : BaseEntity 
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the offerer")]
        public string OffererMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the item thats being sold")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("auctionid of the item thats being sold")]
        public string DMAuctionId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the offer")]
        public string DMOfferId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the member that owns the item")]
        public string MemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("firstname of member")]
        public string FirstName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("lsatname of member")]
        public string LastName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("username of member")]
        public string UserName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("firstname of OffererMember")]
        public string OffererMemberFirstName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("lastname of OffererMember")]
        public string OffererMemberLastName { get; set; }

        [Description("price offered by the bidder")]
        public int OfferValue { get; set; }

        [Description("the biggest bid so far")]
        public int BiggestBid { get; set; }

        [Description("buy it now price")]
        public int BuyItNowPrice { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 10)]
        public DMItemTypes Type { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 70), Description("name of the item, if domain than domain name")]
        public string DomainName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 15), Description("status of the offered auction")]
        public string Status { get; set; }


    }
}