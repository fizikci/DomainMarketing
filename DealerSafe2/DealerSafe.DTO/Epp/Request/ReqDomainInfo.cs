using System;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Represents info command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainInfo : ReqBase, ICommandArgs<ReqDomainInfo, ResDomainInfo>, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainInfoArgs class with specified domain name and authentication information
        /// </summary>
        /// <param name="domainName">Domain name</param>
        /// <param name="authInfo">Authentication information</param>
        public ReqDomainInfo(string domainName, AuthInfo authInfo)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            this.DomainName = domainName;
            this.AuthInfo = authInfo;
        }

        /// <summary>
        /// Initializes a new instance of the DomainInfoArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Domain name</param>
        public ReqDomainInfo(string domainName)
            : this(domainName, null)
        {
        }

        public ReqDomainInfo()
        {
        }

        /// <summary>
        /// Represents value of the hosts attribute
        /// </summary>
        public enum ReturningHosts
        {
            /// <summary>
            /// Returns information describing both subordinate and delegated hosts
            /// </summary>
            All = 0,

            /// <summary>
            /// Returns information describing only subordinate hosts
            /// </summary>
            Subordinate = 1,

            /// <summary>
            /// Returns information describing only delegated hosts
            /// </summary>
            Delegated = 2,

            /// <summary>
            /// Returns no information describing delegated or subordinate hosts
            /// </summary>
            None = 3
        }

        /// <summary>
        /// Gets domain name
        /// </summary>
        public string DomainName { get; set; }

        public string DomainId { get; set; }

        /// <summary>
        /// Gets authentication information
        /// </summary>
        public AuthInfo AuthInfo { get; set; }

        /// <summary>
        /// Gets or sets attribute that available to control return of information describing hosts related to the domain object
        /// </summary>
        public ReturningHosts Hosts { get; set; }

        public Protocol.Launch.infoType ExtLaunch { get; set; }
        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }

        public DirectiDetailTypes DirectiDetailType { get; set; }
        public DirectiOperationTypes DirectiOperationType { get; set; }

        public NicTrDetailTypes NicTrDetailType { get; set; }
        public NicTrOperationTypes NicTrOperationType { get; set; }

        public int DirectiOrderId { get; set; }

        public string NicTrTicketNumber { get; set; } 

        #region ICommandArgs<DomainInfoArgs, DomainInfoResult> Members

        /// <summary>
        /// Fill info command with domain info content
        /// </summary>
        /// <param name="command">Info command</param>
        public void FillCommand(ICommand command)
        {
            var domainNameElement = new XElement(SchemaHelper.DomainNs.GetName("name"), this.DomainName);

            var domainInfoElement = new XElement(SchemaHelper.DomainNs.GetName("info"), domainNameElement);
            domainInfoElement.AddDomainSchemaLocation();
            command.GetCommandElement().Add(domainInfoElement);

            var hostsAttrValue = "all";
            switch (this.Hosts)
            {
                case ReturningHosts.Subordinate:
                    hostsAttrValue = "sub";
                    break;
                case ReturningHosts.Delegated:
                    hostsAttrValue = "del";
                    break;
                case ReturningHosts.None:
                    hostsAttrValue = "none";
                    break;
                case ReturningHosts.All:
                    hostsAttrValue = "all";
                    break;
            }

            domainNameElement.Add(new XAttribute("hosts", hostsAttrValue));

            if (this.AuthInfo != null)
            {
                var authInfoElem = new XElement(SchemaHelper.DomainNs.GetName("authInfo"));
                this.AuthInfo.Fill(authInfoElem);
                domainInfoElement.Add(authInfoElem);
            }
        }

        #endregion
    }

    public enum DirectiDetailTypes
    {
        All = 1,
        OrderDetails = 2,
        ContactIDs = 3,
        RegistrantContactDetails = 4,
        AdminContactDetails = 5,
        TechContactDetails = 6,
        BillingContactDetails = 7,
        NsDetails = 8,
        DomainStatus = 9
    }
    public enum NicTrDetailTypes
    {
        All = 1,
        OrderDetails = 2,
        ContactIDs = 3,
        RegistrantContactDetails = 4,
        AdminContactDetails = 5,
        TechContactDetails = 6,
        BillingContactDetails = 7,
        NsDetails = 8,
        DomainStatus = 9
    }
}