namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Base class for all transfer responses 
    /// </summary>
    /// <typeparam name="TTransferResult">Target transfer result class (represents object specific "trnData" element in response)</typeparam>
    [Serializable]
    public class TransferResponse<TTransferResult> : ResponseBase<TTransferResult>
        where TTransferResult : class, ICommandResult<TTransferResult>, new()
    {
        /// <summary>
        /// Gets transfer status
        /// </summary>
        public TransferStatus Status { get; set; }

        /// <summary>
        /// Gets the identifier of the client that requested the transfer
        /// </summary>
        public string RequestedClientId { get; set; }

        /// <summary>
        /// Gets the date and time that the request was made
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Gets the identifier of the client that is authorized to act on the request
        /// </summary>
        public string ActOnClientId { get; set; }

        /// <summary>
        /// Gets the date and time by which an action is expected
        /// </summary>
        public DateTime ActionDate { get; set; }

        /// <summary>
        /// Gets the date and time noting changes in the object's validity period
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected override string ResultElementName
        {
            get { return "trnData"; }
        }

        /// <summary>
        /// Extracts info response content from the underlying response message
        /// </summary>
        /// <param name="response">Response message</param>
        public override void ExtractResult(ResponseMessageBase response)
        {
            base.ExtractResult(response);

            var trnDataElement = this.GetResultElement();
            var objectNamespace = trnDataElement.Name.Namespace;

            this.Status = trnDataElement.Element(objectNamespace.GetName("trStatus")).Value.ToEnum<TransferStatus>();
            this.RequestedClientId = trnDataElement.Element(objectNamespace.GetName("reID")).Value;
            this.RequestDate = DateTime.Parse(trnDataElement.Element(objectNamespace.GetName("reDate")).Value).ToUniversalTime();
            this.ActOnClientId = trnDataElement.Element(objectNamespace.GetName("acID")).Value;
            this.ActionDate = DateTime.Parse(trnDataElement.Element(objectNamespace.GetName("acDate")).Value).ToUniversalTime();

            var expDateElement = trnDataElement.Element(objectNamespace.GetName("exDate"));
            this.ExpirationDate = expDateElement == null ? (DateTime?)null : DateTime.Parse(expDateElement.Value).ToUniversalTime();
        }
    }
}
