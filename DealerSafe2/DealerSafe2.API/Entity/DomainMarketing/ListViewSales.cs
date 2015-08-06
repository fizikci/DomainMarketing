using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewSales : BaseEntity
    {
        public string SellerMemberId { get; set; }
        public string SellerFullName { get; set; }
        public string BuyerMemberId { get; set; }
        public string BuyerFullName { get; set; }
        public string DMItemId { get; set; }
        public bool IsPrivateSale { get; set; }
        public bool IsDeleted { get; set; }
        public int SaleValue { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DomainName { get; set; }
        public string Ownership { get; set; }
        public bool IsVerified { get; set; }
        public string DescriptionShort { get; set; }

    }
}