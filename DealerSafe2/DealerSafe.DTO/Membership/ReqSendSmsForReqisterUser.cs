using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqSendSmsForReqisterUser
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Mobile country code of the member")]
        public string GSMCC { get; set; }

        [Description("Mobile number of the member")]
        public string Tel { get; set; }

        [Description("Activication Code of the member")]
        public string ActivasyonCode { get; set; }
    }
}
