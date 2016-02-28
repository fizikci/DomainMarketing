using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class SendSmsForReqisterUserInfo
    {
        [Description("Response Code for Send SMS")]
        public int ProcessCode { get; set; }

        [Description("Error message for Send SMS")]
        public string ProcessMessage { get; set; }
    }
}
