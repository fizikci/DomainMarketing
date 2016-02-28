using System;

namespace DealerSafe.DTO.Support
{
    [Serializable]
    public class SupportPosts
    {
        public string Id = "";
        public string TicketId = "";
        public DateTime DateLine;
        public string FullName = "";
        public string Email = "";
        public string Contents = "";
        public string StaffId = "";
    }
}