namespace DealerSafe.DTO.Membership
{
    using System;

    public class MemberLogsInfo
    {
        public int pkMemberLogID { get; set; }
        public decimal fkMemberID { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime EntryTime { get; set; }
        public string IPAddress { get; set; }
        public string SessionID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
    }
}
