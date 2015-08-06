namespace DealerSafe2.DTO.Request
{
    public class ReqComodoResendDCVEmail : BaseRequest
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int OrderNumber { get; set; }
        public string DcvEmailAddress { get; set; }
    }
}
