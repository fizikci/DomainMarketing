using Cinar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    [TableDetail(ViewSQL= @"
        CREATE VIEW ListViewDMMessages AS
        SELECT PDM.Subject,
               PDM.Body,
               M.FromMemberId,
               (FM.FirstName + ' ' + FM.Lastname) AS FromMemberFullname,
               M.Tomemberid,
               (TM.FirstName + ' ' + TM.Lastname) AS ToMemberFullname,
               M.Id,
               M.IsDeleted,
               M.InsertDate
        FROM DMMessage AS M
        INNER JOIN Member AS FM ON M.Frommemberid = FM.Id
        INNER JOIN Member AS TM ON M.Tomemberid = TM.Id
        INNER JOIN DMPredefinedMessage AS PDM ON M.DMPredefinedMessageid = PDM.Id
    ")]
    public class ListViewDMMessages: BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromMemberId { get; set; }
        public string FromMemberFullname { get; set; }
        public string ToMemberId { get; set; }
        public string ToMemberFullname { get; set; }
    }
}