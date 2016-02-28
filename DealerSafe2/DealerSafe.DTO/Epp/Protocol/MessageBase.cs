namespace Epp.Protocol
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Schema;

    /// <summary>
    /// Base class for all EPP messages. Contains some usefull utilities
    /// </summary>
    [Serializable]
    public abstract class MessageBase
    {
        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:contact-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace ContactNs = XNamespace.Get("urn:ietf:params:xml:ns:contact-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:domain-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace DomainNs = XNamespace.Get("urn:ietf:params:xml:ns:domain-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:eppcom-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace EppComNs = XNamespace.Get("urn:ietf:params:xml:ns:eppcom-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:epp-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace EppNs = XNamespace.Get("urn:ietf:params:xml:ns:epp-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:host-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace HostNs = XNamespace.Get("urn:ietf:params:xml:ns:host-1.0");

        /// <summary>
        /// Instance of "http://www.w3.org/2001/XMLSchema" XML namespace
        /// </summary>
        public static readonly XNamespace XmlSchemaNs = XNamespace.Get("http://www.w3.org/2001/XMLSchema");

        /// <summary>
        /// Instance of "http://www.w3.org/2001/XMLSchema-instance" XML namespace
        /// </summary>
        public static readonly XNamespace XsiNs = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

        /// <summary>
        /// XDocument of the message body as string
        /// </summary>
        private string messageDocumentStr;

        /// <summary>
        /// XDocument of the message body
        /// </summary>
        [NonSerialized]
        private XDocument messageDocument;

        /// <summary>
        /// Initializes a new instance of the MessageBase class with specified body and message type
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        /// <param name="messageType">Message type</param>
        protected MessageBase(XDocument messageDocument, MessageType messageType)
        {
            if (messageDocument == null)
            {
                throw new ArgumentNullException("messageDocument");
            }

            this.MessageDocument = messageDocument;
            this.MessageType = messageType;
        }


        /// <summary>
        /// Gets message type
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets XDocument of the message body
        /// </summary>
        protected XDocument MessageDocument
        {
            get
            {
                if (this.messageDocument == null)
                {
                    this.messageDocument = XDocument.Parse(this.messageDocumentStr);
                }

                return this.messageDocument;
            }

            private set
            {
                if (this.messageDocument != value)
                {
                    if (this.messageDocument != null)
                    {
                        this.messageDocument.Changed -= this.OnDocumentChanged;
                    }

                    this.messageDocument = value;
                    this.messageDocument.Changed += this.OnDocumentChanged;
                    this.messageDocument.Declaration = new XDeclaration("1.0", "UTF-8", "no");

                    var sb = new StringBuilder();
                    sb.AppendLine(this.messageDocument.Declaration.ToString());
                    sb.Append(this.messageDocument.ToString());
                    this.messageDocumentStr = sb.ToString();
                }
            }
        }

        /// <summary>
        /// Gets "epp" XML element
        /// </summary>
        protected XElement EppElement
        {
            get
            {
                return this.MessageDocument.Root;
            }
        }

        /// <summary>
        /// Parses (and validates) message, represented as string and construts the EppMessageBase object for the message
        /// </summary>
        /// <param name="message">Message string</param>
        /// <returns>EppMessageBase object</returns>
        public static MessageBase Parse(string message)
        {
            var document = XDocument.Parse(message);
            ////try
            ////{
            ////    document.Validate(SchemaHelper.SchemaSet, null, true);
            ////}
            ////catch (Exception err)
            ////{
            ////    throw new MessageValidationException("Message validation error", err);
            ////}

            if (document.Root == null)
            {
                throw new ArgumentException("Root element not exists");
            }

            var msgElement = document.Root.Elements().FirstOrDefault();
            if (msgElement == null)
            {
                throw new ArgumentException("Message element not exists");
            }

            switch (msgElement.Name.LocalName)
            {
                case "hello":
                    return new HelloMessage(document);
                case "greeting":
                    return new GreetingMessage(document);
                case "response":
                    return new ResponseMessageBase(document);
                default:
                    return new LiteralMessage(document);
            }
        }

        /// <summary>
        /// Validates the message
        /// </summary>
        public void Validate()
        {
            try
            {
                this.MessageDocument.Validate(SchemaHelper.SchemaSet, null, true);
            }
            catch (Exception err)
            {
                throw new MessageValidationException(String.Format("Message validation error. {0}", err.Message), err);
            }
        }

        /// <summary>
        /// Validates the message and return its string representation
        /// </summary>
        /// <returns>String representation of the message</returns>
        public override string ToString()
        {
            ////this.Validate();
            return this.messageDocumentStr;
        }

        /// <summary>
        /// Constructs string summary of the message, used in Demo Application
        /// </summary>
        /// <returns>String summary of the message</returns>
        public virtual string ToSummaryString()
        {
            return String.Format("XML:\n{0}\n\n", this);
        }

        /// <summary>
        /// XDocument.Changed event handler
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void OnDocumentChanged(object sender, XObjectChangeEventArgs args)
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.messageDocument.Declaration.ToString());
            sb.Append(this.messageDocument.ToString());
            this.messageDocumentStr = sb.ToString();
        }
    }
}