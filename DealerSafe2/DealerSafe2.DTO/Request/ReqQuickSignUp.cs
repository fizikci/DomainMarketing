namespace DealerSafe2.DTO.Request
{
    public class ReqQuickSignUp : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
