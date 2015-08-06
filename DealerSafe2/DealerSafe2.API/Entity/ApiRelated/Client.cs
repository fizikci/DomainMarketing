using Cinar.Database;
namespace DealerSafe2.API.Entity.ApiRelated
{
    public class Client : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string AdminMemberId { get; set; }

        public string ConnectionStrings { get; set; }
    }
}