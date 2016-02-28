using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqNictrUpdateNameServer
    {
        public string domain { get; set; }
        public string[] DNSs { get; set; }
        public string[] IPs { get; set; }
    }
}
