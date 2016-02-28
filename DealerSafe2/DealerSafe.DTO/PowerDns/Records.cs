using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.PowerDns
{
    public class Records
    {
        public int id { get; set; }
        public int domain_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public int ttl { get; set; }
        public int? prio { get; set; }
        public int change_date { get; set; }
        public string ordername { get; set; }
        public int auth { get; set; }
    }
}
