using System.ComponentModel;
namespace DealerSafe.DTO.Membership
{
    public class ReqLogin
    {
        [Description("Email address of the member")]
        public string Email { get; set; }

        [Description("Password of the member")]
        public string Password { get; set; }
    }
}