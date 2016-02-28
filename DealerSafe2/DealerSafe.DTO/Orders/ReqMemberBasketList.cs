using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqMemberBasketList
    {
        public string memberSessionKey { get; set; }
        public int orderID { get; set; }
    }
}
