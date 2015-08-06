using System;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class MemberInfo : BaseEntityInfo
    {
        public bool IsAnonim()
        {
            return Id == "";
        }

        public string FullName
        {
            get
            {
                return string.Format(
                                    "{0} {1}",
                                    !String.IsNullOrWhiteSpace(FirstName) ? FirstName : Email.Split('@')[0],
                                    !String.IsNullOrWhiteSpace(LastName) ? LastName : "");
            }
        }

        //public string ClientId { get; set; }
        public MemberStates State { get; set; }
        public MemberTypes MemberType { get; set; }

        public string MemberAddressId { get; set; }
        public string LanguageId { get; set; }
        //public string ReferenceMemberId { get; set; }
        //public string Keyword { get; set; }
        //public string IdentityNo { get; set; }
        //public string FacebookId { get; set; }
        //public string TwitterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        //public string Password { get; set; }
        public string Email { get; set; }
        public string NewEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string GsmPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Avatar { get; set; }
        public string MemberRiskLevel { get; set; }
        public string GeoLocation { get; set; }
        public string CompanyInfo { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Locale { get; set; }
        public int TimeZone { get; set; }

        public DateTime LastLoginDate { get; set; }
        public DateTime CurrLoginDate { get; set; }

        public DMMedals Medal { get; set; }
        public bool GSMPhoneNumberVerified { get; set; }

        //public bool IsStaffMember { get; set; }
        //public Departments StaffDepartment { get; set; }
        public string AlternativeEmail { get; set; }

        //public bool SuperUser { get; set; }
        //public string StaffMemberId { get; set; }
    }
}
