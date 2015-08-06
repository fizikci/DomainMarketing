namespace DealerSafe2.API.Entity.Members
{
    public class Country : NamedEntity, ICriticalEntity
    {
        public string OfficialName { get; set; }
        public string UtcTimeZone { get; set; }
        public string UtcTimeZoneSummer { get; set; }
        public string CallingCode { get; set; }
        public string Iso2Code { get; set; }
        public string Iso3Code { get; set; }
        public string InternetTLD { get; set; }
        public string CurrencyName { get; set; }
        public string OfficalCurrencyName { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string Flag { get; set; }
        public decimal NationalTaxRate { get; set; }
        public string IdentificationNumberFormat { get; set; }


    }
}