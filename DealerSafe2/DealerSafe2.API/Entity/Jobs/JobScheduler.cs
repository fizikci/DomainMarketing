using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Jobs
{
    public class JobScheduler : NamedEntity
    {
        public JobCommands Command { get; set; }

        public DateTime LastExecution { get; set; }
        public int RecurEverySeconds { get; set; }
    }
}