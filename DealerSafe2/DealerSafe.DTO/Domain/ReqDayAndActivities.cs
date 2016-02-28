using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDayAndActivities
    {
        public int DayCount { get; set; }

        public List<int> Activities { get; set; }
    }
}
