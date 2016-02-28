namespace Epp.Protocol.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Represents change information for contact update command
    /// </summary>
    [Serializable]
    public class ContactChangeType
    {
        /// <summary>
        /// Sequence of postal informatios
        /// </summary>
        private List<PostalInfo> postalInfos;

        /// <summary>
        /// Gets or sets a sequence of postal informatios
        /// </summary>
        public List<PostalInfo> PostalInfos
        {
            get
            {
                return this.postalInfos;
            }

            set
            {
                this.postalInfos = (value ?? Enumerable.Empty<PostalInfo>()).ToList();
            }
        }

        /// <summary>
        /// Gets or sets a voice
        /// </summary>
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Gets or sets a fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets authentication information
        /// </summary>
        public AuthInfo Auth { get; set; }

        /// <summary>
        /// Gets or sets disclose rules
        /// </summary>
        public Disclose Disclose { get; set; }

        /// <summary>
        /// Fill change type for the contact
        /// </summary>
        /// <param name="changeTypeElement">Change type</param>
        public void Fill(XElement changeTypeElement)
        {
            if (this.PostalInfos != null)
            {
                foreach (var postalInfo in this.PostalInfos)
                {
                    var postalElem = new XElement(SchemaHelper.ContactNs.GetName("postalInfo"));
                    postalInfo.Fill(postalElem);
                    changeTypeElement.Add(postalElem);
                }
            }

            if (this.Voice != null)
            {
                var voiceElem = new XElement(SchemaHelper.ContactNs.GetName("voice"));
                this.Voice.Fill(voiceElem);
                changeTypeElement.Add(voiceElem);
            }

            if (this.Fax != null)
            {
                changeTypeElement.Add(new XElement(SchemaHelper.ContactNs.GetName("fax"), this.Fax));
            }

            if (this.Email != null)
            {
                changeTypeElement.Add(new XElement(SchemaHelper.ContactNs.GetName("email"), this.Email));
            }

            if (this.Auth != null)
            {
                var authElement = new XElement(SchemaHelper.ContactNs.GetName("authInfo"));
                this.Auth.Fill(authElement);
                changeTypeElement.Add(authElement);
            }

            if (this.Disclose != null)
            {
                var discloseElement = new XElement(SchemaHelper.ContactNs.GetName("disclose"));
                this.Disclose.Fill(discloseElement);
                changeTypeElement.Add(discloseElement);
            }
        }
    }
}
