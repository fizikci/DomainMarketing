using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqChangePassword
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Security code of the member")]
        public string SecurityCode { get; set; }

        [Description("Old password of the member")]
        public string OldPassword { get; set; }

        [Description("New password of the member")]
        public string NewPassword { get; set; }
    }
}
