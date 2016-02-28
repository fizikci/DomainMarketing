namespace Epp.Protocol.Shared
{
    using System;
    using System.Xml.Linq;

    #region Status enum

        /// <summary>
        /// Represents status names
        /// </summary>
        [Serializable]
        public enum Status
        {
            /// <summary>
            /// Requests to delete the object MUST be rejected
            /// </summary>
            ClientDeleteProhibited,

            /// <summary>
            /// DNS delegation information MUST NOT be published for the object
            /// </summary>
            ClientHold,

            /// <summary>
            /// Requests to renew the object MUST be rejected
            /// </summary>
            ClientRenewProhibited,

            /// <summary>
            /// Requests to transfer the object MUST be rejected
            /// </summary>
            ClientTransferProhibited,

            /// <summary>
            /// Requests to update the object (other than to remove this status) MUST be rejected
            /// </summary>
            ClientUpdateProhibited,

            /// <summary>
            /// Delegation information has not been associated with the object
            /// </summary>
            Inactive,

            /// <summary>
            /// This is the normal status value for an object that has no pending operations or prohibitions
            /// </summary>
            Ok,

            /// <summary>
            /// Create command has been processed for the object, but the action has not been completed by the server
            /// </summary>
            PendingCreate,

            /// <summary>
            /// Delete command has been processed for the object, but the action has not been completed by the server
            /// </summary>
            PendingDelete,

            /// <summary>
            /// Renew command has been processed for the object, but the action has not been completed by the server
            /// </summary>
            PendingRenew,

            /// <summary>
            /// Transfer command has been processed for the object, but the action has not been completed by the server
            /// </summary>
            PendingTransfer,

            /// <summary>
            /// Update command has been processed for the object, but the action has not been completed by the server
            /// </summary>
            PendingUpdate,

            /// <summary>
            /// Requests to delete the object MUST be rejected
            /// </summary>
            ServerDeleteProhibited,

            /// <summary>
            /// DNS delegation information MUST NOT be published for the object
            /// </summary>
            ServerHold,

            /// <summary>
            /// Requests to renew the object MUST be rejected
            /// </summary>
            ServerRenewProhibited,

            /// <summary>
            /// Requests to transfer the object MUST be rejected
            /// </summary>
            ServerTransferProhibited,

            /// <summary>
            /// Requests to update the object (other than to remove this status) MUST be rejected
            /// </summary>
            ServerUpdateProhibited,

            /// <summary>
            /// Status MAY be combined with any status
            /// </summary>
            Linked
        }

        #endregion

    /// <summary>
    /// Represents status information
    /// </summary>
    [Serializable]
    public class StatusInfo
    {
        /// <summary>
        /// Initializes a new instance of the StatusInfo class
        /// </summary>
        /// <param name="status">Status name</param>
        /// <param name="text">Status information text</param>
        /// <param name="language">Language of the information text</param>
        public StatusInfo(Status status, string text, string language)
        {
            this.Status = status;
            this.Text = text;
            this.Language = language ?? "en";
        }

        /// <summary>
        /// Initializes a new instance of the StatusInfo class
        /// </summary>
        /// <param name="status">Status name</param>
        public StatusInfo(Status status)
            : this(status, null, null)
        {
        }

        public StatusInfo()
        {
        }

        /// <summary>
        /// Gets status name
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets status information text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets language of the information text
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Extracts StatusInfo object from XML element
        /// </summary>
        /// <param name="statusInfoElement">StatusInfo XML element</param>
        /// <returns>StatusInfo object</returns>
        public static StatusInfo Extract(XElement statusInfoElement)
        {
            var status = statusInfoElement.Attribute("s").Value.ToLowerInvariant().ToEnum<Status>();
            var text = statusInfoElement.Value;
            var language = statusInfoElement.Attribute("en") != null ? statusInfoElement.Attribute("en").Value : null;
            return new StatusInfo(status, text, language);
        }

        /// <summary>
        /// Fill specified XML element with the status info
        /// </summary>
        /// <param name="statusInfoElement">StatusInfo XML element</param>
        public void Fill(XElement statusInfoElement)
        {
            var ch = this.Status.ToString().ToLowerInvariant()[0];
            var status = this.Status.ToString(); 
            status = ch + status.Remove(0, 1);
            statusInfoElement.Add(new XAttribute("s", status));
            if (!String.IsNullOrEmpty(this.Language))
            {
                statusInfoElement.Add(new XAttribute("lang", this.Language));
            }
        }
    }
}
