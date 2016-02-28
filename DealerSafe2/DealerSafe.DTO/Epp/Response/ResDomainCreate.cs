using System;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for domain create command
    /// </summary>
    [Serializable]
    public class ResDomainCreate : ICommandResult<ResDomainCreate>
    {
        /// <summary>
        /// Gets domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets domain creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets domain expiration date
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        public string BatchResult { get; set; }

        public string DirectiResponseActionStatus { get; set; }
        public string DirectiResponseActionStatusDescription { get; set; }
        public string DirectiOrderId { get; set; }
        public string DirectiErrorMessage { get; set; }

        public string NicTrResponseActionStatus { get; set; }
        public string NicTrResponseActionStatusDescription { get; set; }
        public string NicTrOrderId { get; set; }
        public string NicTrErrorMessage { get; set; }

        #region ICommandResult<DomainCreateResult> Members

        /// <summary>
        /// Extracts result from underlying create response
        /// </summary>
        /// <param name="response">Create response</param>
        public void ExtractResult(ResponseBase<ResDomainCreate> response)
        {
            var creDataElem = response.GetResultElement();
            
            this.DomainName = creDataElem.Element(SchemaHelper.DomainNs.GetName("name")).Value;

            this.CreateDate = DateTime.Parse(creDataElem.Element(SchemaHelper.DomainNs.GetName("crDate")).Value).ToUniversalTime();
            
            var expDateElem = creDataElem.Element(SchemaHelper.DomainNs.GetName("exDate"));
            this.ExpireDate = expDateElem == null ? (DateTime?)null : DateTime.Parse(expDateElem.Value).ToUniversalTime();
        }

        #endregion
    }
}