using System;
using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.LifeCycles
{
    public class LifeCyclePhase : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string LifeCycleId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 200)]
        public string Description { get; set; }

        public int Days { get; set; }

        public LifeCyclePhases PhaseType { get; set; }

    }

}