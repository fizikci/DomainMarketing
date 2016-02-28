using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqDeleteMembersAddress
    {
        [Description("ID of the member address")]
        public int Id { get; set; }

        [Description("MemberId of the member address")]
        public int MemberId { get; set; }

    }
}
