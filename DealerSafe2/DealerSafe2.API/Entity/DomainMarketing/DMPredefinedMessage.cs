using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMPredefinedMessage : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100)]
        public string Subject { get; set; }

        [ColumnDetail(ColumnType = DbType.Text), Description("complaint text")]
        public string Body { get; set; }
    }

}