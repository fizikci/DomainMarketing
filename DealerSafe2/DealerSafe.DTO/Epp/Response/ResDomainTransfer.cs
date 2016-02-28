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
    public class ResDomainTransfer : ICommandResult<ResDomainTransfer>, IEppExtension
    {
        /// <summary>
        /// the fully qualified name of the domain object.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// the state of the most recent transfer request
        /// </summary>
        public string TransferRequestState { get; set; }

        /// <summary>
        /// the identifier of the client that requested the object transfer
        /// </summary>
        public string RequesterClientId { get; set; }

        /// <summary>
        /// the date and time that the transfer was requested
        /// </summary>
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// the identifier of the client that SHOULD act upon a PENDING transfer request.
        /// For all other status types, the value identifies the client that took the indicated action
        /// </summary>
        public string ActorClientId { get; set; }

        /// <summary>
        /// the date and time of a required or completed response.
        /// For a PENDING request, the value identifies the date and time by which a response is required before an automated response action will be taken by the server. 
        /// For all other status types, the value identifies the date and time when the request was completed
        /// </summary>
        public DateTime? ActionDate { get; set; }

        /// <summary>
        /// the end of the domain object's validity period if the &lt;transfer&gt; command caused or causes a change in the validity period
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        public string DirectiStatus { get; set; }
        public int DirectiOrderId { get; set; }
        public string DirectiActionStatusDesc { get; set; }
        public string DirectiError { get; set; }


        #region ICommandResult<DomainTransferResult> Members

        /// <summary>
        /// Extracts result from underlying transfer response
        /// </summary>
        /// <param name="response">Transfer response</param>
        public void ExtractResult(ResponseBase<ResDomainTransfer> response)
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
            if (objectElement.Element(SchemaHelper.DomainNs.GetName("name")) != null)
                this.DomainName = objectElement.Element(SchemaHelper.DomainNs.GetName("name")).Value;

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("trStatus")) != null)
                this.TransferRequestState = objectElement.Element(SchemaHelper.DomainNs.GetName("trStatus")).Value;

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("reID")) != null)
                this.RequesterClientId = objectElement.Element(SchemaHelper.DomainNs.GetName("reID")).Value;

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("reDate")) != null)
                this.RequestDate = DateTime.Parse(objectElement.Element(SchemaHelper.DomainNs.GetName("reDate")).Value).ToUniversalTime();

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("acID")) != null)
                this.ActorClientId = objectElement.Element(SchemaHelper.DomainNs.GetName("acID")).Value;

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("acDate")) != null)
                this.ActionDate = DateTime.Parse(objectElement.Element(SchemaHelper.DomainNs.GetName("acDate")).Value).ToUniversalTime();

            if (objectElement.Element(SchemaHelper.DomainNs.GetName("exDate")) != null)
                this.ExpireDate = DateTime.Parse(objectElement.Element(SchemaHelper.DomainNs.GetName("exDate")).Value).ToUniversalTime();

        }

        #endregion
    }
}