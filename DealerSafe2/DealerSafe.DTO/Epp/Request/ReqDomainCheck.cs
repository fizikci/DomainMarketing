using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to check command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainCheck : ReqBase, ICommandArgs<ReqDomainCheck, ResDomainCheck>, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainCheckArgs class
        /// </summary>
        /// <param name="domainNames">Domain names for check</param>
        public ReqDomainCheck(List<string> domainNames)
        {
            if (domainNames == null)
            {
                throw new ArgumentNullException("domainNames");
            }

            List<string> domNames = domainNames.ToList();
            if (domNames.Count == 0)
            {
                throw new ArgumentException("domainNames must be not empty sequence");
            }

            this.DomainNames = domainNames;
        }

        public ReqDomainCheck()
        {
        }

        /// <summary>
        /// Gets domain names for check
        /// </summary>
        public List<string> DomainNames { get; set; }

        public DirectiOperationTypes DirectiOperationType { get; set; }

        public Protocol.Launch.checkType ExtLaunch { get; set; }
        public Protocol.PremiumDomain.chkType ExtPremiumDomain { get; set; }
        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }
        public Protocol.Fee05.checkType ExtFee05 { get; set; }
        public Protocol.Fee06.checkType ExtFee06 { get; set; }
        public Protocol.Fee07.checkType ExtFee07 { get; set; }
        
        #region ICommandArgs<DomainCheckArgs, DomainCheckResult> Members

        /// <summary>
        /// Fill check command with domain check content
        /// </summary>
        /// <param name="command">Check command</param>
        public void FillCommand(ICommand command)
        {
            XNamespace domainNs = SchemaHelper.DomainNs;
            var domainCheckElement = new XElement(SchemaHelper.DomainNs.GetName("check"));

            foreach (var domainName in DomainNames)
                domainCheckElement.Add(new XElement(domainNs + "name", domainName));

            domainCheckElement.AddDomainSchemaLocation();
            command.GetCommandElement().Add(domainCheckElement);
        }
        #endregion
    }

    public interface IVerisignNameStore
    {
        Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }
    }
}