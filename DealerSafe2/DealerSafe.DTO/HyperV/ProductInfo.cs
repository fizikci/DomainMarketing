using DealerSafe.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ProductInfo: BaseEntityObject
    {
        public enum ProductGroup
        {
            VirtualServer = 10
        }

        public enum ProductType
        {
            HyperVPackets = 17,
            HyperVExtensions = 20,
            HyperVOperatingSystems = 21,
            HyperVPanels = 22,
            HyperVSQLServers = 23,
            HyperVUzatma = 25,
            HyperVCpu = 26,
            HyperVRam = 27,
            HyperVDisk = 28,
            HyperVTrafik = 29,
            HyperVIp = 30,
            HyperVIpExtra = 31,            
            HyperVDestek = 34,
            HyperVTrafikExtra = 35,
            HyperVDestekExtra = 39,
            HyperVCPanelComponent = 41
        }

        public enum Product
        {
            HyperVServer = 395,
            EkoPaket = 396,
            Linux = 424,
            Windows = 425,            
            Plesk = 427,
            CPanel = 428,
            Maestro = 540,
            Uzatma = 434,
            PremiumDestek = 433,
            PremiumDestekExtra = 537,
            Ddos = 508,
            Firewall = 538,
            IpExtra1 = 503,
            IpExtra2 = 504,
            IpExtra3 = 505,
            IpExtra4 = 506,
            PhysicalServerUzatma = 541,
            LiteSpeed = 542
        }
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
