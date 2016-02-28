using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetMembersAddressList
    {
        [Description("MemberId of the member address")]
        public int MemberId { get; set; }

        [Description("Type of the member address")]
        public short Type { get; set; }
    }
}
