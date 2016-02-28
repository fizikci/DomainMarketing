using HyperV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ResGetServerConfiguration
    {
        public int Cpu { get; set; }
        public PacketInfo Packet { get; set; }

        public SizeUnit Ram { get; set; }
        public SizeUnit Disk { get; set; }
        public SizeUnit Traffic { get; set; }

        public ProductInfo OperatingSystem { get; set; }
        public ProductInfo Sql { get; set; }
        public ProductInfo Panel { get; set; }
        
        public List<ProductInfo> Ip { get; set; }
        public List<ProductInfo> IpExtra { get; set; }

        public int TotalIp
        {
            get
            {
                return (Packet == null ? 0 : 1) + Ip.Select(ip => int.Parse(ip.Name)).Sum() + IpExtra.Select(ip => int.Parse(ip.Name)).Sum();
            }
        }
    }
}
