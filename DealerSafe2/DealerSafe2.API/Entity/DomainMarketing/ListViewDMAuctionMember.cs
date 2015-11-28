using Cinar.Database;
using System;
using DealerSafe2.DTO.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    [TableDetail(ViewSQL = @"
        CREATE VIEW [ListViewDMAuctionMember]
        AS
        SELECT
          A.[Id] AS DMAuctionId,
          A.[BiggestBid],
          I.[Type],
          I.[DomainName],
          M.[FirstName],
          M.[LastName],
          M.[Id],
          M.[IsDeleted],
          M.[InsertDate]
        FROM Member M
        INNER JOIN DMItem I ON I.SellerMemberId = M.Id
        INNER JOIN DMAuction A ON A.DMItemId = I.Id
    ")]
    public class ListViewDMAuctionMember : BaseEntity
    {
        // Id is Member.Id

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction item(domain/web project)")]
        public string DMAuctionId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 10)]
        public DMItemTypes Type { get; set; }

        [Description("the biggest bid so far")]
        public int BiggestBid { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 70), Description("name of the item, if domain than domain name")]
        public string DomainName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("firstname of user")]
        public string FirstName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("lsatname of user")]
        public string LastName { get; set; }
    }
}