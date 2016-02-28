namespace DealerSafe.DTO.Hosting
{
    using System;
    [Serializable]
    public class MemberProcessLogInfo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int HostingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProcessType { get; set; }
    }
}
