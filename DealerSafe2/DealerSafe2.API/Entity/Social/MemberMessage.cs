using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Social
{
    public class MemberMessage : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12)]
        public string FromMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12)]
        public string ToMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100)]
        public string Subject { get; set; }

        [ColumnDetail(ColumnType = DbType.Text), Description("complaint text")]
        public string Body { get; set; }

        public bool ReadByTo { get; set; }
        public bool ReadByFrom { get; set; }
        public bool DeletedByTo { get; set; }
        public bool DeletedByFrom { get; set; }
    }

}