using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqNewIpAddress
    {
        public int VirtualMachineId { get; set; }
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
    }
}
