using System;

namespace DealerSafe2.DTO.Request
{
    public class ProfileInfo : BaseRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string GsmPhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Gender { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CountryId { get; set; }

        public string StateId { get; set; }

        public string CityId { get; set; }

        public string ZipCode { get; set; }

        public string AddressText { get; set; }

    }
}
