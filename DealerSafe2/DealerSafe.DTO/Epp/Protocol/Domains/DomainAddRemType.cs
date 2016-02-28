namespace Epp.Protocol.Domains
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Represents Add\Remove type for domains
    /// </summary>
    [Serializable]
    public class DomainAddRemType
    {
        /// <summary>
        /// Adding or removing list of contacts
        /// </summary>
        private List<DomainContactInfo> contacts;

        /// <summary>
        /// Status values to be associated with or removed from the object
        /// </summary>
        private List<StatusInfo> statuses;

        /// <summary>
        /// Gets or sets adding or removing list of name servers
        /// </summary>
        public NameServerList NameServers { get; set; }

        /// <summary>
        /// Gets or sets adding or removing list of contacts
        /// </summary>
        public List<DomainContactInfo> Contacts
        {
            get
            {
                return this.contacts;
            }

            set
            {
                this.contacts = (value ?? Enumerable.Empty<DomainContactInfo>()).ToList();
            }
        }

        /// <summary>
        /// Gets or sets status values to be associated with or removed from the object
        /// </summary>
        public List<StatusInfo> Statuses
        {
            get
            {
                return this.statuses;
            }

            set
            {
                this.statuses = (value ?? Enumerable.Empty<StatusInfo>()).ToList();
            }
        }

        /// <summary>
        /// Fill specified XML element with the addRemType information
        /// </summary>
        /// <param name="addRemElement">AddRemElement XML element to fill</param>
        public void Fill(XElement addRemElement)
        {
            if (this.NameServers != null)
            {
                var ns = new XElement(SchemaHelper.DomainNs.GetName("ns"));
                this.NameServers.Fill(ns);
                addRemElement.Add(ns);
            }

            if (this.Contacts != null)
            {
                foreach (var contact in this.Contacts)
                {
                    var con = new XElement(SchemaHelper.DomainNs.GetName("contact"));
                    contact.Fill(con);
                    addRemElement.Add(con);
                }                
            }

            if (this.Statuses != null)
            {
                foreach (var status in this.Statuses)
                {
                    var st = new XElement(SchemaHelper.DomainNs.GetName("status"));
                    status.Fill(st);
                    addRemElement.Add(st);
                }
            }
        }
    }
}
