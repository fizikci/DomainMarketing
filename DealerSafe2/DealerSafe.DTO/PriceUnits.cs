using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class PriceUnits
    {
        public static string GetUnitPrice(string unit)
        {
            switch (unit)
            {
                case "1": return "TL";
                case "2": return "$";
                case "3": return "€";
                default: return "";
            }
        }

        public static string GetUnitStr(string unitStr)
        {
            switch (unitStr)
            {
                case "TL": return "1";
                case "$": return "2";
                case "€": return "3";
                default: return "";
            }
        }
        public static double ConvertUSDToTL(double val, double USDSelling)
        {
            return USDSelling * val;
        }
    }
}
