using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Social
{
    public class MemberComplaint : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12)]
        public string ByMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12)]
        public string ToMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12)]
        public ComplaintTypes Type { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("complaint text")]
        public string Complaint { get; set; }
    }

    public enum ComplaintTypes
    {
        Spam,
        Hate,
        Teror
    }
}