using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Hosting
{
    public class HostingTwinPrice
    {
        public bool IsCampaign { get; set; }
        public float PriceList { get; set; }
        public float PriceReal { get; set; }
        public string Image1 { get; set; }
        public string ImageTop { get; set; }
        public string UrunResim { get; set; }
    }
}
