using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerSafe2.DTO.EntityInfo;

namespace DealerSafe2.DTO.Response
{
    public class ResGetDashboard
    {
        public List<DashboardItem> Messages { get; set; }
        public int CompletedOrders { get; set; }
        public int WaitingOrders { get; set; }
        public int TotalOrderCost { get; set; }
        public int RemainingCredits { get; set; }
        public int SupportMessageCount { get; set; }
    }
}
