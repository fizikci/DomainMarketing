using System;
using System.Collections.Generic;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class OrderInfo : BaseEntityInfo
    {
        public OrderStates State {get; set;}
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public string Currency { get; set; }
        public string DisplayName { get; set; }
        public string InvoiceNo { get; set; }
        public string CouponItemId { get; set; }
        public string DiscountName { get; set; }
        public int Discount { get; set; }

        public List<OrderItemInfo> Items { get; set; }
        public MemberAddressInfo Address { get; set; }
    }
}
