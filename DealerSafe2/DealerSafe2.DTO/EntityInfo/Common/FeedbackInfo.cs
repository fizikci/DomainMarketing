using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo
{
    public class FeedbackInfo : NamedEntityInfo
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Departments Department { get; set; }
    }
}