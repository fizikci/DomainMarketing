namespace DealerSafe2.DTO.Request
{
    public class ReqLoginWithRecoveryQuestion : BaseRequest
    {
        public string Email { get; set; }
        public string Answer { get; set; }
    }
}
