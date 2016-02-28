using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class RegisterUserInfo
    {
        [Description("Process for fast register user")]
        public bool Process { get; set; }

        [Description("Member Number of the member")]
        public int MemberId { get; set; }
    }
}
