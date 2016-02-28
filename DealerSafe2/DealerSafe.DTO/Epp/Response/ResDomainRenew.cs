using System;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for domain renew command
    /// </summary>
    [Serializable]
    public class ResDomainRenew : ICommandResult<ResDomainRenew>
    {
        /// <summary>
        /// Gets domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets domain expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        public string DirectiActionStatusDescription { get; set; }

        public string NicTrActionStatusDescription { get; set; }

        public bool IsDomainRenew { get; set; }

        #region ICommandResult<DomainRenewResult> Members

        /// <summary>
        /// Extracts result from underlying renew response
        /// </summary>
        /// <param name="response">Renew response</param>
        public void ExtractResult(ResponseBase<ResDomainRenew> response)
        {
            XElement renDataElement = response.GetResultElement();
            this.DomainName = renDataElement.Element(SchemaHelper.DomainNs.GetName("name")).Value;
            XElement expDateElement = renDataElement.Element(SchemaHelper.DomainNs.GetName("exDate"));
            this.ExpirationDate = expDateElement == null ? (DateTime?)null : DateTime.Parse(expDateElement.Value).ToUniversalTime();
        }

        #endregion
    }
}