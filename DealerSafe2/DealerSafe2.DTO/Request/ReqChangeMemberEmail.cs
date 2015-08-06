namespace DealerSafe2.DTO.Request
{
    public class ReqChangeMemberEmail : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
