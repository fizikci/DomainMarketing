using System;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to update command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainUpdate : ReqBase, ICommandArgs<ReqDomainUpdate>, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainUpdateArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Deleting domain name</param>
        public ReqDomainUpdate(string domainName)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            this.DomainName = domainName;
        }

        public ReqDomainUpdate()
        {
        }

        /// <summary>
        /// Gets updating domain name
        /// </summary>
        public string DomainName { get; set; }


        /// <summary>
        /// Gets or sets adding information
        /// </summary>
        public DomainAddRemType Add { get; set; }

        /// <summary>
        /// Gets or sets removing information
        /// </summary>
        public DomainAddRemType Rem { get; set; }


        /// <summary>
        /// Gets or sets changing information
        /// </summary>
        public DomainChangeType Chg { get; set; }

        public Protocol.Launch.idContainerType ExtLaunch { get; set; }
        public Protocol.PremiumDomain.reassignType ExtPremiumDomain { get; set; }
        public Protocol.Rgp.updateType ExtRgp { get; set; }
        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }
        public Protocol.KeySys.updateType ExtKeySys { get; set; }

        public DirectiOperationTypes DirectiOperationType { get; set; }

        public NicTrOperationTypes NicTrOperationType { get; set; }

        public string DirectiAssociateXxxTokenId { get; set; }

        #region ICommandArgs<DomainUpdateArgs> Members

        /// <summary>
        /// Fill update command with domain update content
        /// </summary>
        /// <param name="command">Update command</param>
        public void FillCommand(ICommand command)
        {
            var domainNameElem = new XElement(MessageBase.DomainNs.GetName("name"), this.DomainName);
            var domainUpdateElement = new XElement(MessageBase.DomainNs.GetName("update"), domainNameElem);

            if (this.Add != null)
            {
                var add = new XElement(SchemaHelper.DomainNs.GetName("add"));
                this.Add.Fill(add);
                domainUpdateElement.Add(add);
            }


            if (this.Rem != null)
            {
                var rem = new XElement(SchemaHelper.DomainNs.GetName("rem"));
                this.Rem.Fill(rem);
                domainUpdateElement.Add(rem);
            }


            if (this.Chg != null)
            {
                var chg = new XElement(SchemaHelper.DomainNs.GetName("chg"));
                this.Chg.Fill(chg);
                domainUpdateElement.Add(chg);
            }

            domainUpdateElement.AddDomainSchemaLocation();
            command.GetCommandElement().Add(domainUpdateElement);
        }

        #endregion
    }

    public enum DirectiOperationTypes
    {
        ChangeAuthCode,
        AddTheftLock,
        RemoveTheftLock,
        AssociateXxx,
        GetLocks,
        UpdateChildNameServerIpAddress,
        UpdateChildNameServerName,
        DomainNameServerUpdate,
        DomainPrivacyProtectionUpdate,
        GetDomainDates,
        DomainContactIdUpdate,
        GetDomainCns,
        GetAuthInfo,
        GetDirectiOrderId,
        GetDomainAndCurrentStatus,
        DomainCheckForTransfer,
    }

    public enum NicTrOperationTypes
    {
        ChangeAuthCode,
        AddTheftLock,
        RemoveTheftLock,
        AssociateXxx,
        GetLocks,
        UpdateChildNameServerIpAddress,
        UpdateChildNameServerName,
        DomainNameServerUpdate,
        DomainPrivacyProtectionUpdate,
        GetDomainDates,
        DomainContactIdUpdate,
        GetDomainCns,
        GetAuthInfo,
        GetDirectiOrderId,
        GetDomainAndCurrentStatus,
        DomainCheckForTransfer,
        GetExpirationOfDomain,
        QueryTicketStatus
    }
}
