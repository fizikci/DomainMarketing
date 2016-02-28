namespace Epp.Protocol
{
    using System;

    /// <summary>
    /// Base message types
    /// </summary>
    [Serializable]
    public enum MessageType
    {
        /// <summary>
        /// Hello message
        /// </summary>
        Hello = 0,

        /// <summary>
        /// Greeting message
        /// </summary>
        Greeting = 1,

        /// <summary>
        /// Command message
        /// </summary>
        Command = 2,

        /// <summary>
        /// Response message
        /// </summary>
        Response = 3,

        /// <summary>
        /// Any other messages
        /// </summary>
        Literal = 1000,
    }
}