namespace DealerSafe.DTO.Membership
{
    using System;

    public class ReqMemberLogsInfo
    {
        public string Username { get; set; }
        public DateTime EntryDate { get; set; }
        public string Ip { get; set; }
    }
}
