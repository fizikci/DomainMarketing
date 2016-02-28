using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqRegisterUser
    {
        [Description("Type of the member (None = 0,Kurumsal = 1,Bireysel = 2)")]
        public MemberTypeList MemberType { get; set; }

        [Description("Company Name of the member")]
        public string CompanyName { get; set; }

        [Description("Identity number of the member")]
        public string TCKimlikNo { get; set; }

        [Description("Fullname of the member")]
        public string NameSurname { get; set; }

        [Description("Gender of the member (None = 0, Male = 1, Female = 2)")]
        public DealerSafe.DTO.Membership.MemberInfo.GenderType Gender { get; set; }

        [Description("Email address of the member")]
        public string Email { get; set; }

        [Description("Username of the member.Field Type Email")]
        public string Username { get; set; }

        [Description("Password of the member")]
        public string Password { get; set; }

        [Description("Mobile Phone Country Code of the member")]
        public string GSMCC { get; set; }

        [Description("Phone of the member")]
        public string Tel { get; set; }

        [Description("Country of the member")]
        public string Country { get; set; }

        [Description("Security Code of the member")]
        public string SecurityCode { get; set; }

        [Description("Education of the member")]
        public EducationType Education { get; set; }

        [Description("Suggestion of the member")]
        public SuggestionType Suggestion { get; set; }

        [Description("Web address of the member")]
        public string Www { get; set; }

        [Description("IP address of the member")]
        public string IPAddress { get; set; }

        [Description("TC Kimlik no gibi bazı bilgileri es geçmek için")]
        public bool TurkcellHizliAbonelik { get; set; }

        [Description("Yeni Abonelik Tipi")]
        public bool New { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
    }
    public enum MemberTypeList
    {
        Bireysel = 2,
        Kurumsal = 1,
        None = 0
    }
    public enum EducationType
    {
        None = 0,
        IlkOgretim = 1,
        OrtaOgretim = 2,
        YuksekOkul = 3,
        Lisans = 4,
        YuksekLisans = 5,
        Doktora = 6
    }
    public enum SuggestionType
    {
        None = 0,
        AramaMotoru = 1,
        ArkadasTavsiyesi = 2,
        EBulten = 3,
        Facebook = 4,
        Twitter = 5,
        Diger = 6
    }
}
