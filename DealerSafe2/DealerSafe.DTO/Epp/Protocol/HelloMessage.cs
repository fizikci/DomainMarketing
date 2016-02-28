namespace Epp.Protocol
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents EPP hello message wrapper
    /// </summary>
    [Serializable]
    public class HelloMessage : MessageBase
    {
        /// <summary>
        /// Instance of the HelloMessage
        /// </summary>
        private static readonly HelloMessage instance = (HelloMessage)Parse(SchemaHelper.HelloMessage);

        /// <summary>
        /// Initializes a new instance of the HelloMessage class
        /// </summary>
        /// <param name="messageDocument">Hello message document</param>
        internal HelloMessage(XDocument messageDocument)
            : base(messageDocument, MessageType.Hello)
        {
        }

        /// <summary>
        /// Gets instance of this type
        /// </summary>
        public static HelloMessage Instance
        {
            get { return instance; }
        }
    }
}