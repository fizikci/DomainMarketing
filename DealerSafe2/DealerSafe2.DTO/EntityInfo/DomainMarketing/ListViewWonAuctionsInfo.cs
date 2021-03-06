﻿using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class ListViewWonAuctionsInfo : BaseEntityInfo
    {
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public int PaymentAmount { get; set; }
        public string BuyerMemberId { get; set; }
        public DMSaleStates PaymentStatus { get; set; }

    }
}
