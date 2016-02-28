using System;

namespace DealerSafe.DTO.PowerDns
{
    public class Domains
    {
        public int id { get; set; }
        public string name { get; set; }
        public string master { get; set; }
        public int last_check { get; set; }
        public string type { get; set; }
        public int notified_serial { get; set; }
        public string account { get; set; }
        public string cas { get; set; }
    }
}
