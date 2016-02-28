namespace Epp.Protocol
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the raw message wrapper with validation ability
    /// </summary>
    [Serializable]
    public class LiteralMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the LiteralMessage class from XDocument body
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        public LiteralMessage(XDocument messageDocument)
            : base(messageDocument, MessageType.Literal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LiteralMessage class from string body
        /// </summary>
        /// <param name="message">Message body</param>
        public LiteralMessage(string message)
            : base(XDocument.Parse(message), MessageType.Literal)
        {
        }
    }
}