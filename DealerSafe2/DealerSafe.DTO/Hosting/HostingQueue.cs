using System;

namespace DealerSafe.DTO.Hosting
{
    public class HostingQueue
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int HostingId { get; set; }
        public long ProcessTime { get; set; }
        public bool Result { get; set; }
    }
}
