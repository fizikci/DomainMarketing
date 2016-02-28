namespace Epp.Protocol.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents EPP login message
    /// </summary>
    [Serializable]
    public class LoginCommandMessage : CommandMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the LoginCommandMessage class based on greeting with specified client identifier, password and client transaction identifier
        /// </summary>
        /// <param name="greeting">Greeting message</param>
        /// <param name="clientId">Сlient identifier</param>
        /// <param name="password">Password for login</param>
        /// <param name="clientTranId">Client transaction identifier</param>
        public LoginCommandMessage(GreetingMessage greeting, string clientId, string password, string clientTranId)
            : base(CommandType.Login, false, clientTranId)
        {
            var clientIDElement = new XElement(EppNs.GetName("clID"), clientId);
            var passwordElement = new XElement(EppNs.GetName("pw"), password);

            var versionElement = new XElement(EppNs.GetName("version"), greeting.Versions.First());
            var langElement = new XElement(EppNs.GetName("lang"), greeting.Languages.First());

            var optionsElement = new XElement(EppNs.GetName("options"), versionElement, langElement);

            var objURIElements = greeting.ObjectURIs.Select(objUri => new XElement(EppNs.GetName("objURI"), objUri));
            var svcsElement = new XElement(EppNs.GetName("svcs"), objURIElements);

            if (greeting.ExtensionURIs.Any())
            {
                var extURIElements = greeting.ExtensionURIs.Select(extUri => new XElement(EppNs.GetName("extURI"), extUri));
                var svcExtensionElement = new XElement(EppNs.GetName("svcExtension"), extURIElements);
                svcsElement.Add(svcExtensionElement);
            }

            var loginElement = new XElement(EppNs.GetName("login"), clientIDElement, passwordElement, optionsElement, svcsElement);

            this.CommandElement.AddFirst(loginElement);
        }

        /// <summary>
        /// Initializes a new instance of the LoginCommandMessage class based on greeting with specified client identifier and password
        /// </summary>
        /// <param name="greeting">Greeting message</param>
        /// <param name="clientId">Сlient identifier</param>
        /// <param name="password">Password for login</param>
        public LoginCommandMessage(GreetingMessage greeting, string clientId, string password)
            : this(greeting, clientId, password, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LoginCommandMessage class with specified body
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        protected LoginCommandMessage(XDocument messageDocument)
            : base(messageDocument, CommandType.Login)
        {
        }

        /// <summary>
        /// Gets client identifier
        /// </summary>
        public string ClientId
        {
            get { return this.ClientIDElement.Value; }
        }

        /// <summary>
        /// Gets password
        /// </summary>
        public string Password
        {
            get { return this.PasswordElement.Value; }
        }

        /// <summary>
        /// Gets or sets optional new password
        /// </summary>
        public string NewPassword
        {
            get
            {
                return this.NewPWElement == null ? null : this.NewPWElement.Value;
            }

            set
            {
                if (value == null && this.NewPWElement != null)
                {
                    this.NewPWElement.Remove();
                    return;
                }

                if (this.NewPWElement == null)
                {
                    var newPWElement = new XElement(EppNs.GetName("newPW"));
                    this.PasswordElement.AddAfterSelf(newPWElement);
                }

                this.NewPWElement.Value = value;
            }
        }

        /// <summary>
        /// Gets language
        /// </summary>
        public string Language
        {
            get { return this.LangElement.Value; }
        }

        /// <summary>
        /// Gets version
        /// </summary>
        public string Version
        {
            get { return this.VersionElement.Value; }
        }

        /// <summary>
        /// Gets supported object URIs
        /// </summary>
        public List<string> ObjectURIs
        {
            get { return this.ObjURIElements.Select(elem => elem.Value).ToList(); }
        }

        /// <summary>
        /// Gets "clID" XML element
        /// </summary>
        private XElement ClientIDElement
        {
            get
            {
                return this.LoginElement.Element(EppNs.GetName("clID"));
            }
        }

        /// <summary>
        /// Gets "lang" XML element
        /// </summary>
        private XElement LangElement
        {
            get
            {
                return this.OptionsElement.Element(EppNs.GetName("lang"));
            }
        }

        /// <summary>
        /// Gets "login" XML element
        /// </summary>
        private XElement LoginElement
        {
            get
            {
                return this.CommandElement.Element(EppNs.GetName("login"));
            }
        }

        /// <summary>
        /// Gets "options" XML element
        /// </summary>
        private XElement OptionsElement
        {
            get
            {
                return this.LoginElement.Element(EppNs.GetName("options"));
            }
        }

        /// <summary>
        /// Gets "pw" XML element
        /// </summary>
        private XElement PasswordElement
        {
            get
            {
                return this.LoginElement.Element(EppNs.GetName("pw"));
            }
        }

        /// <summary>
        /// Gets "svcs" XML element
        /// </summary>
        private XElement SvcsElement
        {
            get
            {
                return this.LoginElement.Element(EppNs.GetName("svcs"));
            }
        }

        /// <summary>
        /// Gets "version" XML element
        /// </summary>
        private XElement VersionElement
        {
            get
            {
                return this.OptionsElement.Element(EppNs.GetName("version"));
            }
        }

        /// <summary>
        /// Gets "newPW" XML element
        /// </summary>
        private XElement NewPWElement
        {
            get
            {
                return this.LoginElement.Element(EppNs.GetName("newPW"));
            }
        }

        /// <summary>
        /// Gets the list of the "objURI" elements of the login message
        /// </summary>
        private List<XElement> ObjURIElements
        {
            get { return this.SvcsElement.Elements(EppNs.GetName("objURI")).ToList(); }
        }
    }
}