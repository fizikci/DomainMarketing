using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetMemberMessages
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }
    }
}
