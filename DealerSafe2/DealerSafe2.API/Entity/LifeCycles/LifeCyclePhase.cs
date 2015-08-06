using Cinar.Database;
namespace DealerSafe2.API.Entity.LifeCycles
{
    public class LifeCyclePhase : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string LifeCycleId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 200)]
        public string Description { get; set; }

        public int Days { get; set; }
    }

}