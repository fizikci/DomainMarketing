using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqTldPriceUpdate
    {

        public decimal CompanyId { get; set; }

        public int TldId { get; set; }

        public float Price { get; set; }

        public float Cost { get; set; }

        public float OnTalepSelling { get; set; }

        public float SunRiseSelling { get; set; }

        public float LandRushSelling { get; set; }

    }
}
