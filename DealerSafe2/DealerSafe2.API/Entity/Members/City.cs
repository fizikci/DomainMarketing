using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public class City : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string CountryId { get; set; }
        [ColumnDetail(Length = 12)]
        public string StateId { get; set; }
        public string OfficialName { get; set; }
        public string Abbreviation { get; set; }
        public string CallingCityCode { get; set; }
        public string WebSite { get; set; }
        public string ZipCode { get; set; }

        public Country Country() { return Provider.ReadEntityWithRequestCache<Country>(CountryId); }
        public State State() { return Provider.ReadEntityWithRequestCache<State>(StateId); }

    }
}