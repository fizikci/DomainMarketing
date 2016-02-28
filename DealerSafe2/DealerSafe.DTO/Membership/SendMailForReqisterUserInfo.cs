using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class SendMailForReqisterUserInfo
    {
        [Description("Response Code for Send Mail")]
        public int ProcessCode { get; set; }

        [Description("Error message for Send Mail")]
        public string ProcessMessage { get; set; }
    }
}
