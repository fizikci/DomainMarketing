using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMBrokerage : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the requesting member")]
        public string RequesterMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the broker member")]
        public string BrokerMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the item")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public DMBrokerageStates Status { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("broker's report")]
        public string ReportContent { get; set; }

    }

    public enum DMBrokerageStates
    { 
        Open,
        BeingEdited,
        Processed
    }
}