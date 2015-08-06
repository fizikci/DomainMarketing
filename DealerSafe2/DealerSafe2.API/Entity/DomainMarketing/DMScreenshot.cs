using Cinar.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMScreenshot : NamedEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the web project, fk referencing the item table")]
        public string DMItemId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 200), Description("path to the screenshot jpg file")]
        public string RelativePath { get; set; }

    }
}