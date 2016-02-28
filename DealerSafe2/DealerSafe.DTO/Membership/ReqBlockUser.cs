using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqBlockUser
    {
        [Description("ID of the member")]
        public int MemberId { get; set; }

        [Description("Message for system admin")]
        public string Message { get; set; }
    }
}
