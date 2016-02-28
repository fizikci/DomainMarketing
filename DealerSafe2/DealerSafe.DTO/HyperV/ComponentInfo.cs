using DealerSafe.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ComponentInfo: BaseEntityObject
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
    }
}
