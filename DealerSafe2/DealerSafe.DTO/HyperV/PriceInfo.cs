using DealerSafe.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class PriceInfo
    {
        public int Period { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerPeriod { get; set; }
        public decimal Gain { get; set; }

        public int Discount { get; set; }
        public bool IsDefault { get; set; }        
    }    
}
