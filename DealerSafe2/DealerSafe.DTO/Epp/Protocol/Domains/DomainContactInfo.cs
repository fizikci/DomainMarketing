namespace Epp.Protocol.Domains
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents information about domain contact
    /// </summary>
    [Serializable]
    public class DomainContactInfo
    {
        /// <summary>
        /// Initializes a new instance of the DomainContactInfo class
        /// </summary>
        /// <param name="contactId">Contact identifier</param>
        /// <param name="contactType">Domain contact type</param>
        public DomainContactInfo(string contactId, ContactType contactType)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException("contactId");
            }

            this.ContactId = contactId;
            this.Type = contactType;
        }

        public DomainContactInfo() : this("CONTACT_ID", ContactType.Admin)
        {
        }

        #region ContactType enum

        /// <summary>
        /// Domain contact type
        /// </summary>
        [Serializable]
        public enum ContactType
        {
            /// <summary>
            /// Domain administrator
            /// </summary>
            Admin,

            /// <summary>
            /// Dommain billing
            /// </summary>
            Billing,

            /// <summary>
            /// Domain tech
            /// </summary>
            Tech
        }

        #endregion

        /// <summary>
        /// Gets contact identifier
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets domain contact type
        /// </summary>
        public ContactType Type { get; set; }

        /// <summary>
        /// Extracts domain contact from the XML element
        /// </summary>
        /// <param name="contactElement">Domain contact XML element</param>
        /// <returns>Domain contact</returns>
        public static DomainContactInfo Extract(XElement contactElement)
        {
            var contactType = contactElement.Attribute("type").Value.ToEnum<ContactType>();
            return new DomainContactInfo(contactElement.Value, contactType);
        }

        /// <summary>
        /// Fills specified contact XML element with contact data
        /// </summary>
        /// <param name="contactElement">Filling XML element</param>
        public void Fill(XElement contactElement)
        {
            contactElement.SetValue(this.ContactId);
            contactElement.Add(new XAttribute("type", this.Type.ToString().ToLowerInvariant()));
        }
    }
}