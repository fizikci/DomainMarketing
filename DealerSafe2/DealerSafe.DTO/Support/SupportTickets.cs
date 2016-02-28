using System;

namespace DealerSafe.DTO.Support
{
    [Serializable]
    public class SupportTickets
    {
        public string ticketid = "";
        public string displayid = "";
        public string statusid = "";
        public string priorityid = "";
        public string fullname = "";
        public DateTime creationtime;
        public DateTime lastactivity;
        public string subject = "";
    }
}