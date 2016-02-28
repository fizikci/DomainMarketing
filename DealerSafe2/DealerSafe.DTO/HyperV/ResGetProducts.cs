using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ResGetProducts
    {
        public List<PacketInfo> Packets { get; set; }

        public List<ProductInfo> OperatingSystems { get; set; }
        public List<ProductInfo> ControlPanels { get; set; }
        public List<ProductInfo> SQLServers { get; set; }
        public List<ProductInfo> Support { get; set; }
        public List<ProductInfo> SupportExtra { get; set; }
        public List<ProductInfo> Other { get; set; }

        public List<ProductInfo> Cpu { get; set; }
        public List<ProductInfo> Ram { get; set; }
        public List<ProductInfo> Disk { get; set; }
        public List<ProductInfo> Trafik { get; set; }
        public List<ProductInfo> Ip { get; set; }
        public List<ProductInfo> IpExtra { get; set; }
        public List<ProductInfo> TrafikExtra { get; set; }
        public List<ProductInfo> CPanelPlugins { get; set; }

        public List<DiscountInfo> Discounts { get; set; }
    }
}
