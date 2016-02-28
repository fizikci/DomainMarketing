namespace Epp.Protocol.Commands
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents EPP poll message
    /// </summary>
    [Serializable]
    public class PollCommandMessage : CommandMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the PollCommandMessage class with specified client transaction identifier for request operation
        /// </summary>
        /// <param name="clientTranId">Client transaction identifier</param>
        public PollCommandMessage(string clientTranId)
            : this(clientTranId, OperationType.Request, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PollCommandMessage class with specified client transaction identifier and message identifier for acknoledge the message
        /// </summary>
        /// <param name="clientTranId">Client transaction identifier</param>
        /// <param name="messageId">Message identifier</param>
        public PollCommandMessage(string clientTranId, string messageId)
            : this(clientTranId, OperationType.Acknowledge, messageId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PollCommandMessage class with specified client transaction identifier, poll operation type and message identifier
        /// </summary>
        /// <param name="clientTranId">Client transaction identifier</param>
        /// <param name="operationType">Poll operation type</param>
        /// <param name="messageId">Message identifier</param>
        private PollCommandMessage(string clientTranId, OperationType operationType, string messageId)
            : base(CommandType.Poll, false, clientTranId)
        {
            var operationAttr = new XAttribute("op", operationType == OperationType.Request ? "req" : "ack");
            var pollElement = new XElement(SchemaHelper.EppNs.GetName("poll"), operationAttr);
            if (messageId != null)
            {
                var msgIDAttr = new XAttribute("msgID", messageId);
                pollElement.Add(msgIDAttr);
            }

            this.CommandElement.AddFirst(pollElement);
        }

        #region OperationType enum

        /// <summary>
        /// Poll operation type
        /// </summary>
        [Serializable]
        public enum OperationType
        {
            /// <summary>
            /// Retrieving the first message from the server message queue
            /// </summary>
            Request,

            /// <summary>
            /// Acknowledging receipt of a message
            /// </summary>
            Acknowledge
        }

        #endregion

        /// <summary>
        /// Gets poll operation type
        /// </summary>
        public OperationType Operation
        {
            get
            {
                var operationType = this.PollElement.Attribute("op").Value;
                return operationType == "req" ? OperationType.Request : OperationType.Acknowledge;
            }
        }

        /// <summary>
        /// Gets message identifier
        /// </summary>
        public string MessageId
        {
            get
            {
                var msgIdAttr = this.PollElement.Attribute("msgID");
                return msgIdAttr == null ? null : msgIdAttr.Value;
            }
        }

        /// <summary>
        /// Gets "poll" XML element
        /// </summary>
        private XElement PollElement
        {
            get
            {
                return this.CommandElement.Element(SchemaHelper.EppNs.GetName("poll"));
            }
        }
    }
}