using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewSalesInfo : BaseEntityInfo
    {
        public string SellerMemberId { get; set; }
        public string SellerFullName { get; set; }
        public string BuyerMemberId { get; set; }
        public string BuyerFullName { get; set; }
        public bool IsPrivateSale { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public DMSaleStates PaymentStatus { get; set; }
        public DMAuctionStateReasons StatusReason { get; set; }
        public string PaymentDescription { get; set; }
        public DMItemTypes Type { get; set; }
        public string DomainName { get; set; }
        public string Ownership { get; set; }
        public bool IsVerified { get; set; }
        public string DescriptionShort { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
