using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class MemberAddressInfo : BaseEntityInfo
    {
        public string MemberId { get; set; }

        public string Email { get; set; } // if not a member
        public string FullName { get; set; } // if not a member
        public string PhoneNumber { get; set; } // if not a member

        public AddressTypes AddressType {get; set;}

        public string InvoiceTitle {get; set;}

        public string CountryId {get; set;}

        public string StateId { get; set; }

        public string CityId { get; set; }

        public string ZipCode {get; set;}

        public string AddressText {get; set;}

        public string CityName {get; set;}

        public string TaxOffice {get; set;}

        public string TaxNumber {get; set;}
    }
}
