namespace DealerSafe.DTO.MobileBridge
{
    public class ReqRegisterMemberSendSms
    {
        public int MemberId { get; set; }
        public string PhoneCc { get; set; }
        public string Gsm { get; set; }
        public string ActivasyonCode { get; set; }
    }
}
