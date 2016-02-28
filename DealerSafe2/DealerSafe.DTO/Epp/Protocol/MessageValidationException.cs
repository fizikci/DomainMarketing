namespace Epp.Protocol
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Validation error exception
    /// </summary>
    [Serializable]
    public class MessageValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MessageValidationException class
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="inner">Inner exception</param>
        public MessageValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MessageValidationException class (Serilization support)
        /// </summary>
        /// <param name="info">SerializationInfo object</param>
        /// <param name="context">StreamingContext object</param>
        protected MessageValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}