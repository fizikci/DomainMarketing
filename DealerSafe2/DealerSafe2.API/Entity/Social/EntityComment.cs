using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Social
{
    public class EntityComment : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the commenter member")]
        public string MemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("ilgili entity")]
        public string EntityName { get; set; }
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("ilgili entity")]
        public string EntityId { get; set; }

        public int Rating { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("comment text")]
        public string Comment { get; set; }
    }
}