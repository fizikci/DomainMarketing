using System;
using System.Collections.Generic;
using System.Linq;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for contact check command
    /// </summary>
    [Serializable]
    public class ResContactCheck : ICommandResult<ResContactCheck>
    {
        /// <summary>
        /// Gets information about checked contacts
        /// </summary>
        public List<CheckInfo> ContactInfos { get; set; }

        #region ICommandResult<ContactCheckResult> Members

        /// <summary>
        /// Extracts result from underlying check response
        /// </summary>
        /// <param name="response">Check response</param>
        public void ExtractResult(ResponseBase<ResContactCheck> response)
        {
            this.ContactInfos = response
                .GetCDItems()
                .Select(cd => new CheckInfo(cd.ObjectElement.Value, cd.Available, cd.Reason))
                .ToList();
        }

        #endregion

        #region Nested type: CheckInfo

        /// <summary>
        /// Information about one checked contact
        /// </summary>
        [Serializable]
        public class CheckInfo
        {
            /// <summary>
            /// Initializes a new instance of the CheckInfo class
            /// </summary>
            /// <param name="contactId">Checked contact identifier</param>
            /// <param name="available">Whether contact is available for provisioning</param>
            /// <param name="reason">Reason of unavailablity or null</param>
            internal CheckInfo(string contactId, bool available, string reason)
            {
                this.ContactId = contactId;
                this.Available = available;
                this.Reason = reason;
            }

            public CheckInfo()
            {
            }

            /// <summary>
            /// Gets the checked contact identifier
            /// </summary>
            public string ContactId { get; set; }

            /// <summary>
            /// Gets a value indicating whether contact is available for provisioning
            /// </summary>
            public bool Available { get; set; }

            /// <summary>
            /// Gets the reason of unavailablity if any
            /// </summary>
            public string Reason { get; set; }
        }

        #endregion

        public bool IsAvailable(string contactId)
        {
            var contactInfo = ContactInfos.First(ci => ci.ContactId == contactId);
            return contactInfo == null ? false : contactInfo.Available;
        }
    }
}