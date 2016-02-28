using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ReqOrgMousePadStatusChange
    {
        public int ID { get; set; }
        public string CurrentStatus { get; set; }
        public string NewStatus { get; set; }
    }
}
