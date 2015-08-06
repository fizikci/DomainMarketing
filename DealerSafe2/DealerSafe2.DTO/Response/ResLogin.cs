using DealerSafe2.DTO.EntityInfo;

namespace DealerSafe2.DTO.Response
{
    public class ResLogin
    {
        public string SessionId { get; set; }
        public MemberInfo Member { get; set; }
    }
}
