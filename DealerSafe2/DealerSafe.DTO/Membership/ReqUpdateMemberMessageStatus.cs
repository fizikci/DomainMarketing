using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateMemberMessageStatus
    {
        [Description("Message ID of the member message")]
        public int MessageId { get; set; }

        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Message status update of the member message")]
        public bool MessagStatus { get; set; }
    }
}
