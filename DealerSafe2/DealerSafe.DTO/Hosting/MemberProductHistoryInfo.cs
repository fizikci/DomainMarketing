using System;

namespace DealerSafe.DTO.Hosting
{
    public class MemberProductHistoryInfo
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateMemberId { get; set; }
        public int PrevOrderDetailId { get; set; }
        public string PrevSrvIP { get; set; }
        public string PrevCName { get; set; }
        public string PrevOS { get; set; }
        public int OrderDetailId { get; set; }
        public string SrvIP { get; set; }
        public string CName { get; set; }
        public DateTime ProcessDate { get; set; }
        public string HistoryType { get; set; }
    }
}
