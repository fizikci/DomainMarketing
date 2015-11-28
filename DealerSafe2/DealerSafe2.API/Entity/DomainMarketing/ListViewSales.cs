using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    [TableDetail(ViewSQL=@"
        CREATE VIEW Listviewsales AS
        SELECT S.Id,
               S.Sellermemberid,
               (Sm.Firstname + ' ' + Sm.Lastname) AS Sellerfullname,
               S.Buyermemberid,
               (Bm.Firstname + ' ' + Bm.Lastname) AS Buyerfullname,
               S.Dmitemid,
               I.Domainname,
               I.Type,
               I.Ownership,
               I.Isverified,
               I.Descriptionshort,
               S.Isprivatesale,
               S.Isdeleted,
               S.Salevalue,
               S.Paymenttype,
               S.Status,
               S.Description,
               S.Insertdate
        FROM Dmsale AS S
        INNER JOIN Dmitem I ON S.Dmitemid = I.Id
        LEFT JOIN Member Sm ON Sm.Id = S.Sellermemberid
        LEFT JOIN Member Bm ON Bm.Id = S.Buyermemberid
    ")]
    public class ListViewSales : BaseEntity
    {
        public string SellerMemberId { get; set; }
        public string SellerFullName { get; set; }
        public string BuyerMemberId { get; set; }
        public string BuyerFullName { get; set; }
        public string DMItemId { get; set; }
        public bool IsPrivateSale { get; set; }
        public int SaleValue { get; set; }
        public string PaymentType { get; set; }
        public DMSaleStates Status { get; set; }
        public string Description { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string Ownership { get; set; }
        public bool IsVerified { get; set; }
        public string DescriptionShort { get; set; }

    }
}