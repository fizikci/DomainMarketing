using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class WaitingPaymentInfo : BaseEntityInfo
    {
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public int SaleValue { get; set; }
        public string SellerMemberId { get; set; }
        public string BuyerMemberId { get; set; }
        public DMAuctionStates Status { get; set; }
        public DMAuctionStateReasons StatusReason { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
