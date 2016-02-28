namespace DealerSafe.DTO.MobileBridge
{
   public class ReqRegisterMember
    {
       public string Email { get; set; }
       public string Password { get; set; }
       public string Gsm { get; set; }
       public short ReferrerType { get; set; }
       public string PhoneCc { get; set; }
       public string IpAddress { get; set; }
    }
}
