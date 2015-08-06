using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMExpertise : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the requesting member")]
        public string RequesterMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the expert member")]
        public string ExpertMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the item")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public DMExpertiseStates Status { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("broker's report")]
        public string ReportContent { get; set; }

        public bool IsPublic { get; set; }
    }

    public enum DMExpertiseStates
    { 
        Open,
        BeingEdited,
        Processed
    }
}