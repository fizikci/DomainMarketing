using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeleteOrdersDetail
    {
        public int ExtraRenewal { get; set; }
        public bool ExtraRenewalSpecified { get; set; }

        public int TargetID { get; set; }
        public bool TargetIDSpecified { get; set; }
        
        public List<Int32> ProductTypeId { get; set; }
        public bool ProductTypeIdSpecified { get; set; }
    }
}
