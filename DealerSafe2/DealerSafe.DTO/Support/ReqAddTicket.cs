
namespace DealerSafe.DTO.Support
{
    public class ReqAddTicket
    {
        public string Subject { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public string DepartmentId { get; set; }
        public string TicketStatusId { get; set; }
        public string TicketPriorityId { get; set; }
        public string TicketTypeId { get; set; }
        public string UserId { get; set; }
    }
}
