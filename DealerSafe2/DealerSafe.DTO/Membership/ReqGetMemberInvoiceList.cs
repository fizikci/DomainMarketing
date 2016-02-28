using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetMemberInvoiceList
    {
        [Description("Id of the member")]
        public int MemberId { get; set; }
    }
}
