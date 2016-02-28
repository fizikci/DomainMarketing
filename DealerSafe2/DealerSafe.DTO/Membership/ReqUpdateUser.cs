using System;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateUser
    {
        [Description("Member number of the member")]
        public int MemberId { get; set; }

        [Description("Type of the member (None = 0,Kurumsal = 1,Bireysel = 2)")]
        public MemberTypeList MemberType { get; set; }

        [Description("Company Name of the member")]
        public string CompanyName { get; set; }

        [Description("Fullname of the member")]
        public string NameSurname { get; set; }

        [Description("Gender of the member (None = 0, Male = 1, Female = 2)")]
        public DealerSafe.DTO.Membership.MemberInfo.GenderType Gender { get; set; }

        [Description("Birth date of the member.Format yyyy-MM-dd")]
        public string BirthDate { get; set; }

        [Description("Education of the member")]
        public EducationType Education { get; set; }

        [Description("Suggestion of the member")]
        public SuggestionType Suggestion { get; set; }

        [Description("Web address of the member")]
        public string Www { get; set; }

        [Description("Country")]
        public string Country { get; set; }
    }
}
