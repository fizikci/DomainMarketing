using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class StaticIPTypesInfo
    {
        public bool Process { get; set; }
        public List<StaticIPTypeDetail> StaticIPTypesList { get; set; }

        public class StaticIPTypeDetail
        {
            public int Id { get; set; }
            public double Price1Quantity { get; set; }
            public double Price2Quantity { get; set; }
            public double Price3Quantity { get; set; }
            public double Price4Quantity { get; set; }
            public double Price5Quantity { get; set; }
        }
    }
}
