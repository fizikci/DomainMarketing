using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to transfer command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainTransfer : ReqBase, ICommandArgs<ReqDomainTransfer, ResDomainTransfer>, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainTransferArgs class
        /// </summary>
        /// <param name="domainName">Transfering domain name</param>
        /// <param name="period">Number of units to be added to the registration period</param>
        /// <param name="authInfo">Domain authentication info</param>
        public ReqDomainTransfer(string domainName, DomainPeriod period, AuthInfo authInfo)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            this.DomainName = domainName;
            this.Period = period;
            this.AuthInfo = authInfo;
        }

        /// <summary>
        /// Initializes a new instance of the DomainTransferArgs class
        /// </summary>
        /// <param name="domainName">Transfering domain name</param>
        /// <param name="period">Number of units to be added to the registration period</param>
        public ReqDomainTransfer(string domainName, DomainPeriod period)
            : this(domainName, period, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DomainTransferArgs class
        /// </summary>
        /// <param name="domainName">Transfering domain name</param>
        public ReqDomainTransfer(string domainName)
            : this(domainName, null, null)
        {
        }

        public ReqDomainTransfer()
        {
        }

        /// <summary>
        /// Gets transfering domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets number of units to be added to the registration period
        /// </summary>
        public DomainPeriod Period { get; set; }

        /// <summary>
        /// Gets or sets domain authentication info
        /// </summary>
        public AuthInfo AuthInfo { get; set; }

        public List<DomainContactInfo> DirectiContactInfo { get; set; }

        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }

        #region ICommandArgs<DomainTransferArgs, DomainTransferResult> Members

        /// <summary>
        /// Fills transfer command with domain transfer content
        /// </summary>
        /// <param name="command">Transfer command</param>
        public void FillCommand(ICommand command)
        {
            var nameElement = new XElement(SchemaHelper.DomainNs.GetName("name"), this.DomainName);
            var domainTransferElement = new XElement(SchemaHelper.DomainNs.GetName("transfer"), nameElement);

            if (this.Period != null)
            {
                var periodElem = new XElement(SchemaHelper.DomainNs.GetName("period"));
                this.Period.Fill(periodElem);
                domainTransferElement.Add(periodElem);
            }

            if (this.AuthInfo != null)
            {
                var authInfoElem = new XElement(SchemaHelper.DomainNs.GetName("authInfo"));
                this.AuthInfo.Fill(authInfoElem);
                domainTransferElement.Add(authInfoElem);
            }

            domainTransferElement.AddDomainSchemaLocation();
            command.GetCommandElement().Add(domainTransferElement);
        }

        #endregion
    }

    public class ReqDomainTransferApprove : ReqDomainTransfer
    {
    }
    public class ReqDomainTransferCancel : ReqDomainTransfer
    {
    }
    public class ReqDomainTransferQuery : ReqDomainTransfer
    {
        public int DirectiOrderId { get; set; }
    }
    public class ReqDomainTransferReject : ReqDomainTransfer
    {
    }
    public class ReqDomainTransferRequest : ReqDomainTransfer
    {
    }
}