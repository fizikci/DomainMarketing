using Cinar.Database;
namespace DealerSafe2.API.Entity.Members
{
    public class District : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string CityId { get; set; }
        public string OfficialName { get; set; }
        public string Abbreviation { get; set; }
        public string WebSite { get; set; }

        public City City() { return Provider.ReadEntityWithRequestCache<City>(CityId); }

    }
}