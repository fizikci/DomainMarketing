using System;
using System.Collections.Generic;
using System.Linq;

namespace DealerSafe2.DTO.EntityInfo
{
    public class ExchangeRateInfo : BaseEntityInfo
    {
        public string Currency { get; set; }
        public int PriceTL { get; set; }
    }

    public class ExchangeRates : List<ExchangeRateInfo>
    {
        public DateTime Date { get; set; }

        public float GetRate(string fromExchange, string toExchange)
        {
            var fromRate = this.FirstOrDefault(r => r.Currency == fromExchange);
            var toRate = this.FirstOrDefault(r => r.Currency == toExchange);

            int fromRatePriceTL = fromRate == null ? 1000000 : fromRate.PriceTL;
            int toRatePriceTL = toRate == null ? 1000000 : toRate.PriceTL;

            return fromRatePriceTL / (float)toRatePriceTL;
        }
    }
}
