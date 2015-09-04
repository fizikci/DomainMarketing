using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewWaitingPayment : BaseEntity 
    {
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public int SaleValue { get; set; }
        public string SellerMemberId { get; set; }
        public string BuyerMemberId { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
