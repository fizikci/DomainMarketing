namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Represents greeting message
    /// </summary>
    [Serializable]
    public class GreetingMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the GreetingMessage class with specified body
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        internal GreetingMessage(XDocument messageDocument)
            : base(messageDocument, MessageType.Greeting)
        {
            // ReSharper disable PossibleNullReferenceException
            var greetingElement = this.EppElement.Element(EppNs.GetName("greeting"));
            this.ServiceId = greetingElement.Element(EppNs.GetName("svID")).Value;
            this.ServiceDate = DateTime.Parse(greetingElement.Element(EppNs.GetName("svDate")).Value);

            var svcMenuElement = greetingElement.Element(EppNs.GetName("svcMenu"));
            this.Languages = svcMenuElement
                .Elements(EppNs.GetName("lang"))
                .Select(elem => elem.Value)
                .ToList();
            this.Versions = svcMenuElement
                .Elements(EppNs.GetName("version"))
                .Select(elem => elem.Value)
                .ToList();
            this.ObjectURIs = svcMenuElement
                .Elements(EppNs.GetName("objURI"))
                .Select(elem => elem.Value)
                .ToList();

            var svcExtensionElement = svcMenuElement.Element(EppNs.GetName("svcExtension"));
            this.ExtensionURIs = svcExtensionElement != null ? svcExtensionElement
                                                                   .Elements(EppNs.GetName("extURI"))
                                                                   .Select(elem => elem.Value).ToList() : new List<string>();

            // ReSharper restore PossibleNullReferenceException
        }

        /// <summary>
        /// Gets service identifier. Value of "svID" element
        /// </summary>
        public string ServiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets service date (UTC)
        /// </summary>
        public DateTime ServiceDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets language. Value of "lang" element
        /// </summary>
        public List<string> Languages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets version. Value of "version" element
        /// </summary>
        public List<string> Versions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets supported objects URIs
        /// </summary>
        public List<string> ObjectURIs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets supported extension URIs
        /// </summary>
        public List<string> ExtensionURIs
        {
            get;
            set;
        }

        /// <summary>
        /// Constructs string summary of the message, used in Demo Application
        /// </summary>
        /// <returns>String summary of the message</returns>
        public override string ToSummaryString()
        {
            var summBuilder = new StringBuilder();

            summBuilder.AppendLine("Greeting:");
            summBuilder.AppendFormat("\tServiceId: {0}\n", this.ServiceId);
            summBuilder.AppendFormat("\tServiceDate: {0}\n", this.ServiceDate);
            summBuilder.AppendFormat("\tVersion: {0}\n", this.Versions.First());
            summBuilder.AppendFormat("\tLanguage: {0}\n", this.Languages.First());
            summBuilder.AppendLine("\tObject URI:");
            foreach (string uri in this.ObjectURIs)
            {
                summBuilder.AppendFormat("\t\t{0}\n", uri);
            }

            summBuilder.AppendLine();
            summBuilder.Append(base.ToSummaryString());
            return summBuilder.ToString();
        }
    }
}