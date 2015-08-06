using System;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo.Jobs
{
    public class JobInfo : NamedEntityInfo
    {
        public JobCommands Command { get; set; }

        public JobStates State { get; set; }

        public string ParentJobId { get; set; }

        public DateTime StartDate { get; set; }
        public string OrderItemId { get; set; }
        public int ProcessTime { get; set; }

        public int TryCount { get; set; }
        public int CompletePercentage { get; set; }

        public JobExecuters Executer { get; set; }
        public string ExecuterId { get; set; }
    }


}