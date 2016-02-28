using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqChangeGSM
    {
        [Description("Id of the member")]
        public int MemberId { get; set; }

        [Description("Phone CC of the member")]
        public string PhoneCC { get; set; }

        [Description("Phone of the member")]
        public string Phone { get; set; }
    }
}
