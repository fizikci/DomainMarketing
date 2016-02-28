using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeleteMemberBasket
    {
        public List<DeletProductDetail> ProductList { get; set; }

        public class DeletProductDetail
        {
            public int BasketID { get; set; }
            public int MemberID { get; set; }
            public string MemberSessionKey { get; set; }
            public int ProductID { get; set; }
        }
    }
}
