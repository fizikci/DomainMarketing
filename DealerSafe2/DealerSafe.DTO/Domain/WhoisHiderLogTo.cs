namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class WhoisHiderLogTo
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool DoSendRegistrant { get; set; }
        public bool DoSendAdmin { get; set; }
        public bool DoSendTech { get; set; }
        public bool DoSendBill { get; set; }

        /// <summary>
        /// Abuse or Contact
        /// </summary>
        public string TypeOfLog { get; set; }

        /// <summary>
        /// Type of abuse from dropdown
        /// </summary>
        public string AbuseType { get; set; }

        public string Ip { get; set; }
        public DateTime Creation { get; set; }

        public string ErrorMessage { get; set; }
    }
}
