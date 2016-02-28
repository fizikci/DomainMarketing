using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqSendMailForReqisterUser
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Username of the member")]
        public string Username { get; set; }

        [Description("Password of the member")]
        public string Password { get; set; }

        [Description("Fullname of the member")]
        public string Fullname { get; set; }
    }
}
