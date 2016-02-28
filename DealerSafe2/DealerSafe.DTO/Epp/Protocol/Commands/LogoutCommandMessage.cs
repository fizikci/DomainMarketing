namespace Epp.Protocol.Commands
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents EPP logout message
    /// </summary>
    [Serializable]
    public class LogoutCommandMessage : CommandMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the LogoutCommandMessage class
        /// </summary>
        /// <param name="clientTranId">Client transaction identifier</param>
        public LogoutCommandMessage(string clientTranId)
            : base(CommandType.Logout, false, clientTranId)
        {
            var logoutElement = new XElement(EppNs.GetName("logout"));
            this.CommandElement.AddFirst(logoutElement);
        }

        /// <summary>
        /// Initializes a new instance of the LogoutCommandMessage class
        /// </summary>
        public LogoutCommandMessage()
            : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogoutCommandMessage class
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        protected LogoutCommandMessage(XDocument messageDocument)
            : base(messageDocument, CommandType.Logout)
        {
        }
    }
}