using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMMessage : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction, fk referencing DMPredefinedMessage table")]
        public string DMPredefinedMessageId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the sender, fk referencing Member table")]
        public string FromMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the receiver, fk referencing Member table")]
        public string ToMemberId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class ListDMMessage : DMMessage
    {
        public string FromMemberFullName { get; set; }
        public string ToMemberFullName { get; set; }
    }
}