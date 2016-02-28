using DealerSafe.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class PacketInfo: BaseEntityObject
    {
        public string Name { get; set; }
        public string Css { get; set; }        

        public decimal Price { get; set; }
        public bool IsPromoted { get; set; }
        public Dictionary<string, ComponentInfo> Components { get; set; }
    }
}
