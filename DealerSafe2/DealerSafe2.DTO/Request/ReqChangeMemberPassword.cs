namespace DealerSafe2.DTO.Request
{
    public class ReqChangeMemberPassword : BaseRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}
