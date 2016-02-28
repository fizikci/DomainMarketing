using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class CalculateMarkPricInfo
    {
        public bool Process { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal MarkServicePrice { get; set; }
        public decimal MarkTotalPrice { get; set; }
    }
}
