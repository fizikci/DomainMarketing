using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Common
{
    public class ReqSendSMS
    {
        [Description("Type of the sms")]
        public enmSmsType smsType { get; set; }

        [Description("Member Number of the Member")]
        public int MemberId { get; set; }

        [Description("Language Code of the sms")]
        public string LangCode { get; set; }

        [Description("For Contact Confirmation")]
        public string PhoneCc { get; set; }

        [Description("For Contact Confirmation")]
        public string PhoneNumber { get; set; }

        [Description("Parameters of the sms.Example template parameter : {DomainName},{MailAddress},...")]
        public List<ParamType> Params { get; set; }
    }
    public class ParamType
    {
        [Description("Name of the parameters")]
        public string ParamName { get; set; }

        [Description("Value of the parameters")]
        public string ParamValue { get; set; }
    }
    public enum enmSmsType
    {
        None = 0,
        signup = 1,
        info = 2,
        domainmove = 3,
        activation = 4,
        password = 5,
        domaininfo = 6,
        hostinfo = 7,
        emailqueue = 8,
        contactapproving = 9
    }
}
