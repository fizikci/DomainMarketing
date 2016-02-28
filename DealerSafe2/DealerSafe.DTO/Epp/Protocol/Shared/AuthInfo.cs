namespace Epp.Protocol.Shared
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represent an element that contains authorization information to be associated with the contact object
    /// </summary>
    [Serializable]
    public class AuthInfo
    {
        /// <summary>
        /// Initializes a new instance of the AuthInfo class
        /// </summary>
        /// <param name="password">Password value</param>
        /// <param name="roid">Repository identifier</param>
        public AuthInfo(string password, string roid)
        {
            this.Password = password;
            this.Roid = roid;
        }

        /// <summary>
        /// Initializes a new instance of the AuthInfo class
        /// </summary>
        /// <param name="password">Password value</param>
        public AuthInfo(string password)
            : this(password, null)
        {
        }

        public AuthInfo() : this("", null)
        {
        }

        /// <summary>
        /// Gets password value
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets repository identifier
        /// </summary>
        public string Roid { get; set; }

        /// <summary>
        /// Extracts AuthInfo object from XML element
        /// </summary>
        /// <param name="authInfoElement">AuthInfo XML element</param>
        /// <returns>AuthInfo object</returns>
        public static AuthInfo Extract(XElement authInfoElement)
        {
            var passwordElement = authInfoElement.Elements().FirstOrDefault(elem => elem.Name.LocalName == "pw");
            if (passwordElement != null)
            {
                var password = passwordElement.Value;
                var roidAttr = passwordElement.Attribute("roid");
                var roid = roidAttr == null ? null : roidAttr.Value;
                return new AuthInfo(password, roid);
            }

            throw new NotSupportedException("Extended authentication information curently not supported");
        }

        /// <summary>
        /// Fill specified authInfo XML element with the authentication info
        /// </summary>
        /// <param name="authInfoElement">AuthInfo XML element</param>
        public void Fill(XElement authInfoElement)
        {
            var objectNamespace = authInfoElement.Name.Namespace;
            var passwordElement = new XElement(objectNamespace.GetName("pw"));
            if (!string.IsNullOrEmpty(this.Password))
            {
                passwordElement.SetValue(this.Password);
            }
            
            if (!String.IsNullOrEmpty(this.Roid))
            {
                passwordElement.Add(new XAttribute("roid", this.Roid));
            }

            authInfoElement.Add(passwordElement);
        }
    }
}