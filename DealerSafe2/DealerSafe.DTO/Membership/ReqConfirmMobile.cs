using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqConfirmMobile
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Activication code of the member")]
        public string ActivationCode { get; set; }
    }
}
