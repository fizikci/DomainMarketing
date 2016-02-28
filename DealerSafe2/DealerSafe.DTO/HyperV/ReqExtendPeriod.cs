using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqExtendPeriod
    {
        public int ServerId { get; set; }
        public int PeriodMonths { get; set; }
    }
}
