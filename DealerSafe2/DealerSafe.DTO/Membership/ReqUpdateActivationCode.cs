using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateActivationCode
    {
        [Description("ID of the member")]
        public int MemberId { get; set; }

        [Description("Activation Code of the member")]
        public string ActivationCode { get; set; }
    }
}
