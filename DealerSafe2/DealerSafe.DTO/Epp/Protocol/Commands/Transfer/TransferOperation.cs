namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Presents transfer operation
    /// </summary>
    [Serializable]
    public enum TransferOperation
    {
        /// <summary>
        /// Transfer request
        /// </summary>
        Request,

        /// <summary>
        /// Check a pending transfer status
        /// </summary>
        Query,

        /// <summary>
        /// Cancel a pending transfer
        /// </summary>
        Cancel,

        Approve,
        Reject
    }
}
