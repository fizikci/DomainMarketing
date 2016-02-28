using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class CreateOrderOnDatabaseInfo
    {
        public int ProductServerID { get; set; }
        public BasketDetail Basket { get; set; }
    }
}
