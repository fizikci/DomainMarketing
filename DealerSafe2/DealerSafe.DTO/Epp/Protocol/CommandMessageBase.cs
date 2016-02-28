namespace Epp.Protocol
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the base class for all command messages
    /// </summary>
    [Serializable]
    public class CommandMessageBase : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the CommandMessageBase class with specified command type and initial options
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="hasExtension">Specifies whether the message would be contain the extension element</param>
        /// <param name="clientTranId">Client transaction identifier</param>
        public CommandMessageBase(CommandType commandType, bool hasExtension, string clientTranId)
            : base(SchemaHelper.CreateEppBaseDocument(), MessageType.Command)
        {
            this.CommandType = commandType;
            var commandElement = new XElement(EppNs.GetName("command"));
            this.EppElement.Add(commandElement);
            if (hasExtension)
            {
                var extensionElement = new XElement(EppNs.GetName("extension"));
                commandElement.Add(extensionElement);
            }

            if (clientTranId != null)
            {
                if (clientTranId.Length < 4 || clientTranId.Length > 64)
                {
                    throw new ArgumentException("Invalid length of clientTranID", "clientTranId");
                }

                var clientTranIdElem = new XElement(EppNs.GetName("clTRID"), clientTranId);
                commandElement.Add(clientTranIdElem);
            }
        }

        /// <summary>
        /// Initializes a new instance of the CommandMessageBase class with specified command type with no of extension element and client transaction identifier
        /// </summary>
        /// <param name="commandType">Command type</param>
        public CommandMessageBase(CommandType commandType)
            : this(commandType, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandMessageBase class with specified body and command type
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        /// <param name="commandType">Command type</param>
        protected CommandMessageBase(XDocument messageDocument, CommandType commandType)
            : base(messageDocument, MessageType.Command)
        {
            this.CommandType = commandType;
        }

        /// <summary>
        /// Gets or sets client transaction identifier
        /// </summary>
        /// <remarks>When transaction identifier not exists this property returns null</remarks>
        public string ClientTranId
        {
            get
            {
                return this.ClientTranIdElement == null ? null : this.ClientTranIdElement.Value;
            }

            set
            {
                if (value == null && this.ClientTranIdElement != null)
                {
                    this.ClientTranIdElement.Remove();
                    return;
                }

                if (this.ClientTranIdElement == null)
                {
                    var clientTranIdElem = new XElement(EppNs.GetName("clTRID"));
                    this.CommandElement.Add(clientTranIdElem);
                }

                this.ClientTranIdElement.Value = value;
            }
        }

        /// <summary>
        /// Gets command type
        /// </summary>
        public CommandType CommandType { get; set; }

        /// <summary>
        /// Gets "command" XML element
        /// </summary>
        public XElement CommandElement
        {
            get
            {
                return this.EppElement.Element(EppNs.GetName("command"));
            }
        }

        /// <summary>
        /// Gets "extension" XML element if exist or null otherwize
        /// </summary>
        public XElement ExtensionElement
        {
            get
            {
                return this.CommandElement.Element(EppNs.GetName("extension"));
            }
        }

        /// <summary>
        /// Gets "clTRID" XML Element
        /// </summary>
        private XElement ClientTranIdElement
        {
            get
            {
                return this.CommandElement.Element(EppNs.GetName("clTRID"));
            }
        }

        /// <summary>
        /// Sets the extension of the command
        /// </summary>
        /// <param name="extension">Command extension object</param>
        public void SetExtension(ICommandExtension extension)
        {
            if (this.ExtensionElement == null)
            {
                var extensionElement = new XElement(EppNs.GetName("extension"));
                //this.CommandElement.Add(extensionElement);

                //fix: extension should be placed before TranId
                var clTRIDElement = this.ClientTranIdElement;
                if (clTRIDElement != null) clTRIDElement.AddBeforeSelf(extensionElement);
                else this.CommandElement.Add(extensionElement);
            }

            //this.ExtensionElement.RemoveAll();
            extension.Fill(this.ExtensionElement);
        }
    }
}