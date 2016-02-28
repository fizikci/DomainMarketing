using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateMemberMessageRead
    {
        [Description("Message ID of the member message")]
        public int MessageId { get; set; }

        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Message read of the member message")]
        public bool MessageRead { get; set; }
    }
}
