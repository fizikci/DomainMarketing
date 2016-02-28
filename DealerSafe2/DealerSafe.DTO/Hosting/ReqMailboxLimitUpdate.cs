namespace DealerSafe.DTO.Hosting
{
    public class ReqMailboxLimitUpdate
    {
        public int HostingId { get; set; }
        public int ProductId { get; set; }
        public bool Unlimited { get; set; }
    }
}
