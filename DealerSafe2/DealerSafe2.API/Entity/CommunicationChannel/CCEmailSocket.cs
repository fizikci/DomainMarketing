using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCEmailSocket : NamedEntity
    {

        public string Host { get; set; }

        public int Port { get; set; }

        public string Credentials { get; set; }

        public DeliveryFormat DeliveryFormat { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public bool EnableSsl { get; set; }

        public string PickupDirectoryLocation { get; set; }

        public string TargetName { get; set; }

        public int Timeout { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public string CertFile { get; set; }

        public string MailFrom { get; set; }

        public string MailSender { get; set; }

        public string MailReply { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int UnitPrice { get; set; }

        public int Capacity { get; set; }

        public string Performance { get; set; }

        public string LogDetails { get; set; }

        public string RealtimeResult { get; set; }

        public string Status { get; set; }

    }



}