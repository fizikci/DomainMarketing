using Cinar.Database;
namespace DealerSafe2.API.Entity.Members
{
    public class State : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string CountryId { get; set; }
        public string OfficialName { get; set; }
        public string Abbreviation { get; set; }
        public string UtcTimeZone { get; set; }
        public string UtcTimeZoneSummer { get; set; }

        public Country Country() { return Provider.ReadEntityWithRequestCache<Country>(CountryId); }

    }
}