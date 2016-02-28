using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqForgotPassword
    {
        [Description("Reminder Type of the Forgot Password")]
        public ReminderTypeList ReminderType { get; set; }

        [Description("Reminder Content of the Forgot Password")]
        public string ReminderContent { get; set; }

        [Description("Security Code of the Forgot Password")]
        public string SecurityCode { get; set; }

        public enum ReminderTypeList
        {
            None = 0,
            Username = 1,
            Email = 2,
            DomainName = 3,
            TcNo = 4
        }
    }
}
