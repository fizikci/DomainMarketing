using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.DTO.Enums;
using Cinar.Database;

namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCProfile : NamedEntity
    {
        [ColumnDetail(Length = 12)]
        public string ClientId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 20)]
        public ProfileType ProfileType { get; set; }

        public Priority Priority { get; set; }

        public string SendName { get; set; }

        public string SendMail { get; set; }

        public string ReplyMail { get; set; }

        public int Status { get; set; }

        public string Note { get; set; }

        public string CCEmailSocketId { get; set; }

        public string CCSmsSocketId { get; set; }

    }
    public class ListViewCCProfile : BaseEntity
    {
        public string Name { get; set; }

        public ProfileType ProfileType { get; set; }

        public Priority Priority { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

    }
    public class ViewCCProfile : CCProfile
    {
        public string ClientName { get; set; }
    }
}