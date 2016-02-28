using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Common
{
    public class ReqSendTurkcellSMS
    {
        public int MemberId { get; set; }
        public string PhoneCc { get; set; }

        [Description("For Contact Confirmation")]
        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
