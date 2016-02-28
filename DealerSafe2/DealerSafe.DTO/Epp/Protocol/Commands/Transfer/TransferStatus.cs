namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Presents transfer status
    /// </summary>
    [Serializable]
    public enum TransferStatus
    {
        /// <summary>
        /// Transfer operation approved by client
        /// </summary>
        ClientApproved,

        /// <summary>
        /// Transfer operation cancelled by client
        /// </summary>
        ClientCancelled,

        /// <summary>
        /// Transfer operation rejected by client
        /// </summary>
        ClientRejected,

        /// <summary>
        /// Transfer operation is in pending state
        /// </summary>
        Pending,

        /// <summary>
        /// Transfer operation approved by server
        /// </summary>
        ServerApproved,

        /// <summary>
        ///  Transfer operation cancelled by server
        /// </summary>
        ServerCancelled
    }
}
