using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Members
{
    public class MemberAddress : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 16)]
        public AddressTypes AddressType { get; set; }

        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public string InvoiceTitle { get; set; }
        [ColumnDetail(Length = 12)]
        public string CountryId { get; set; }
        [ColumnDetail(Length = 12)]
        public string StateId { get; set; }
        [ColumnDetail(Length = 12)]
        public string CityId { get; set; }
        public string ZipCode { get; set; }
        public string AddressText { get; set; }
        public string CityName { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }
        public Country Country() { return Provider.ReadEntityWithRequestCache<Country>(CountryId); }
        public State State() { return Provider.ReadEntityWithRequestCache<State>(StateId); }
        public City City() { return Provider.ReadEntityWithRequestCache<City>(CityId); }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",this.AddressText,this.City().Name,this.State().Name, this.Country().Name);
        }
    }

    public class ListViewMemberAddress : BaseEntity
    {
        public string MemberId { get; set; }
        public string AddressType { get; set; }
        public string InvoiceTitle { get; set; }
    }

}
