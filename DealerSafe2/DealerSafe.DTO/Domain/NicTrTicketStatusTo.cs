namespace DealerSafe.DTO.Domain
{
    using System.ComponentModel;

    public class NicTrTicketStatusTo
    {
        [Description("Ticket Status")]
        public string TicketStatus { get; set; }

        [Description("Hata")]
        public string Hata { get; set; }
    }
}
