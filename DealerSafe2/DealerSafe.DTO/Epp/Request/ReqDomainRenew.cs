using System;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to renew command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainRenew : ReqBase, ICommandArgs<ReqDomainRenew, ResDomainRenew>, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainRenewArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Renewing domain name</param>
        /// <param name="currExpirationDate">The date on which the current validity period ends</param>
        /// <param name="period">Number of units to be added to the registration period</param>
        public ReqDomainRenew(string domainName, DateTime currExpirationDate, DomainPeriod period)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            this.DomainName = domainName;
            this.CurrExpirationDate = currExpirationDate;
            this.Period = period;
        }

        /// <summary>
        /// Initializes a new instance of the DomainRenewArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Renewing domain name</param>
        /// <param name="currExpirationDate">The date on which the current validity period ends</param>
        public ReqDomainRenew(string domainName, DateTime currExpirationDate)
            : this(domainName, currExpirationDate, null)
        {
        }

        public ReqDomainRenew()
        {
        }

        /// <summary>
        /// Gets renewing domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets the date on which the current validity period ends
        /// </summary>
        public DateTime CurrExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets number of units to be added to the registration period
        /// </summary>
        public DomainPeriod Period { get; set; }

        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }

        #region ICommandArgs<DomainRenewArgs, DomainRenewResult> Members

        /// <summary>
        /// Fills renew command with domain renew content
        /// </summary>
        /// <param name="command">Renew command</param>
        public void FillCommand(ICommand command)
        {
            var nameElement = new XElement(SchemaHelper.DomainNs.GetName("name"), this.DomainName);
            var date = this.CurrExpirationDate.ToUniversalTime().Date;
            var dateStr = String.Format("{0:D4}-{1:D2}-{2:D2}", date.Year, date.Month, date.Day);
            var curExpDateElement = new XElement(SchemaHelper.DomainNs.GetName("curExpDate"), dateStr);
            var domainRenewElement = new XElement(SchemaHelper.DomainNs.GetName("renew"), nameElement, curExpDateElement);

            if (this.Period != null)
            {
                var periodElem = new XElement(SchemaHelper.DomainNs.GetName("period"));
                this.Period.Fill(periodElem);
                domainRenewElement.Add(periodElem);
            }

            domainRenewElement.AddDomainSchemaLocation();

            command.GetCommandElement().Add(domainRenewElement);
        }

        public bool DirectiIsRestore { get; set; }

        #endregion
    }
}