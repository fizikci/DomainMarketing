namespace DealerSafe.DTO.Hosting
{
    public class ReqMoveHostingForAdmin
    {
        public int ServerId { get; set; }
        public string Desc { get; set; }
        public bool Backup { get; set; }
        public int OldMemberProductId { get; set; }
    }
}
