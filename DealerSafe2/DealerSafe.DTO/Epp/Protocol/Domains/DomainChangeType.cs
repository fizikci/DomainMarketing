namespace Epp.Protocol.Domains
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Represents domain change information for domain update command
    /// </summary>
    [Serializable]
    public class DomainChangeType
    {
        /// <summary>
        /// Initializes a new instance of the DomainChangeType class
        /// </summary>
        /// <param name="registrant">Identifier for the
        /// human or organizational social information (contact) object to be
        /// associated with the domain object as the object registrant</param>
        public DomainChangeType(string registrant)
        {
            if (registrant == null)
            {
                throw new ArgumentNullException("registrant");
            }

            this.Registrant = registrant;
        }

        /// <summary>
        /// Initializes a new instance of the DomainChangeType class
        /// </summary>
        /// <param name="auth">Authorization information associated with the domain object</param>
        public DomainChangeType(AuthInfo auth)
        {
            if (auth == null)
            {
                throw new ArgumentNullException("auth");
            }

            this.Auth = auth;
        }

        public DomainChangeType()
        {
        }

        /// <summary>
        /// Gets or sets identifier for the
        /// human or organizational social information (contact) object to be
        /// associated with the domain object as the object registrant
        /// </summary>
        public string Registrant { get; set; }

        /// <summary>
        /// Gets or sets authorization information associated with the domain object
        /// </summary>
        public AuthInfo Auth { get; set; }

        /// <summary>
        /// Extracts changing information from XML element
        /// </summary>
        /// <param name="chgElement">XML element containing the authentication information and registrant's login</param>
        /// <returns>ChangeType object, containing information about authentication information and registrant's login</returns>
        public static DomainChangeType Extract(XElement chgElement)
        {
            var registrant = chgElement
                .Elements()
                .FirstOrDefault(elem => elem.Name.LocalName == "registrant")
                .Value;
            var auth = chgElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "authInfo")
                .Select(authInfo => AuthInfo.Extract(authInfo))
                .FirstOrDefault();
            DomainChangeType chgType;
            if (registrant != null)
            {
                chgType = new DomainChangeType(registrant);
                if (auth != null)
                {
                    chgType.Auth = auth;
                }
            }
            else
            {
                chgType = new DomainChangeType(auth);
            }

            return chgType;
        }

        /// <summary>
        /// Fill specified XML element with the authentication information and registrant's login
        /// </summary>
        /// <param name="chgElement">ChangeType XML element to fill</param>
        public void Fill(XElement chgElement)
        {
            if (!String.IsNullOrEmpty(this.Registrant))
            {
                chgElement.Add(new XElement(SchemaHelper.DomainNs.GetName("registrant"), this.Registrant));
            }

            if (this.Auth != null)
            {
                var authInfoElement = new XElement(SchemaHelper.DomainNs.GetName("authInfo"));
                this.Auth.Fill(authInfoElement);
                chgElement.Add(authInfoElement);
            }
        }
    }
}
