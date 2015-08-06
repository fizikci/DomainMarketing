using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMSale : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the seller")]
        public string SellerMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the buyer")]
        public string BuyerMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the item being sold")]
        public string DMItemId { get; set; }

        public bool IsPrivateSale { get; set; }

        [Description("the value of the sold item")]
        public int SaleValue { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20), Description("the payment type code (Will reference the codes defined in payment gateway)")]
        public string PaymentType { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public DMSaleStates Status { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("comments")]
        public string Description { get; set; }

    }

}