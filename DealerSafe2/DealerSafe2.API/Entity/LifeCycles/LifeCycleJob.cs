using Cinar.Database;
using DealerSafe2.DTO.Enums;
namespace DealerSafe2.API.Entity.LifeCycles
{
    public class LifeCycleJob : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string LifeCycleId { get; set; }

        public int RunAtDay { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 50)]
        public JobCommands Command { get; set; }

        public string RelatedEntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string RelatedEntityId { get; set; }

        public JobExecuters Executer { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 200)]
        public string Description { get; set; }
    }

}