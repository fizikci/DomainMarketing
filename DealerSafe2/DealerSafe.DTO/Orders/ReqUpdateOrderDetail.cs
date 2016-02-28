using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqUpdateOrderDetail
    {
        public int OrderDetailID { get; set; }
        
        public double ProductPrice { get; set; }
        public bool ProductPriceSpecified { get; set; }
        
        public double ProductPriceWithQuantity { get; set; }
        public bool ProductPriceWithQuantitySpecified { get; set; }
        
        public string ProductQuantityType { get; set; }
        public bool ProductQuantityTypeSpecified { get; set; }

        public double ProductQuantity { get; set; }
        public bool ProductQuantitySpecified { get; set; }
    }
}
