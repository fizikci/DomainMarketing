using System.ComponentModel;
namespace DealerSafe.DTO.Membership
{
    public class ReqGetMemberInfo
    {
        [Description("Id of the member")]
        public int Id { get; set; }
    }
}