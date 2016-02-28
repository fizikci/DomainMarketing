using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class MarkPriceListInfo
    {
        public bool Process { get; set; }

        public double MarkaYenileme { get; set; }
        public double MarkaYenileme_Hizmeti { get; set; }

        public double MakaAdresDegisikligi { get; set; }
        public double MakaAdresDegisikligi_Hizmeti { get; set; }

        public double MarkaUnvanDegisikligi { get; set; }
        public double MarkaUnvanDegisikligi_Hizmeti { get; set; }

        public double MarkNeviDegisikligi { get; set; }
        public double MarkNeviDegisikligi_Hizmeti { get; set; }

        public double MarkDevirYenileme { get; set; }
        public double MarkDevirYenileme_Hizmeti { get; set; }

        public double MarkLisans { get; set; }
        public double MarkLisans_Hizmeti { get; set; }

        public double EnstitüKararlarınaItiraz { get; set; }
        public double EnstitüKararlarınaItiraz_Hizmeti { get; set; }

        public double MarkaYayinaItiraz { get; set; }
        public double MarkaYayinaItiraz_Hizmeti { get; set; }

        public double MarkaSavunna { get; set; }
        public double MarkaSavunna_Hizmeti { get; set; }

        public double MarkBelgeDuzenleme { get; set; }
        public double MarkBelgeDuzenleme_Hizmeti { get; set; }
    }
}
