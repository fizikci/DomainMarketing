using System;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Reperesents a data for the transfer command
    /// </summary>
    [Serializable]
    public class ResContactTransfer : ICommandResult<ResContactTransfer>, IEppExtension
    {
        /// <summary>
        /// Gets the server-unique identifier
        /// </summary>
        public string ContactId { get; set; }

        #region ICommandResult<ContactTransferResult> Members

        /// <summary>
        /// Extracts result from underlying transfer response
        /// </summary>
        /// <param name="response">Transfer response</param>
        public void ExtractResult(ResponseBase<ResContactTransfer> response)
        {
            this.Extract(response.GetResultElement());
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        public void Extract(XElement objectElement)
        {
            this.ContactId = objectElement.Element(SchemaHelper.ContactNs.GetName("id")).Value;
        }

        #endregion
    }
}