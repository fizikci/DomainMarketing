using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Dns
{
    public class DnsServer
    {
        public int Id { get; set; }
        public int DnsType { get; set; }
        public string Description { get; set; }
        public string ServerIp { get; set; }
        public string ServerPassword { get; set; }
        public int ServerPort { get; set; }
    }
}
