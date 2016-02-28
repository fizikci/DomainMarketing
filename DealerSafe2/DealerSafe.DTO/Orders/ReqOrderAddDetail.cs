using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe.DTO.Orders
{
    public class ReqOrderAddDetail
    {
        public int MemberId { get; set; }
        public OrderDetailInfo OrderDetail { get; set; }
    }

    public enum Currencies
    {
        USD,
        TL,
        EUR
    }
}