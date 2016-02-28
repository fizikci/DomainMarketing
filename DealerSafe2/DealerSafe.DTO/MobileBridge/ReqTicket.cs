namespace DealerSafe.DTO.MobileBridge
{
    public class ReqTicket
    {
        public string MemberId { get; set; }
        //public string department { get; set; } // TODO: Departman yerine konu gönderilmeli
        public string Email { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string Subject { get; set; } // TODO: bu alan zorunludur.
    }
}
