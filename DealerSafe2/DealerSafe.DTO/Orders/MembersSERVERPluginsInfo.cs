using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class MembersSERVERPluginsInfo
    {
        public bool Process { get; set; }
        public List<MembersServerPluginsDetail> MembersServerPluginsList { get; set; }

        public class MembersServerPluginsDetail
        {
            public int Id { get; set; }
            public decimal ServerID { get; set; }
            public decimal MemberID { get; set; }
            public decimal OrderID { get; set; }
            public int ProductID { get; set; }
            public bool Status { get; set; }
            public string Date { get; set; }
        }
    }
}
