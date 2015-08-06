using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Epp.Protocol;
using Cinar.Database;

namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCSentMessage:BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }

        [ColumnDetail(Length = 12)]
        public string CCMessageTemplateId { get; set; }

        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string JobId { get; set; }

        public string MessageType { get; set; }

    }
}