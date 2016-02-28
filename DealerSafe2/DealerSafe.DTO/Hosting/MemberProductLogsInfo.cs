namespace DealerSafe.DTO.Hosting
{
    using System;

    [Serializable]
    public class MemberProductLogsInfo
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public int ProcessType { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessMember { get; set; }
        public int ProductId { get; set; }
    }
}
