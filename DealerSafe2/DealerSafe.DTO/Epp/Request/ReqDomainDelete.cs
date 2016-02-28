using System;
using System.ComponentModel;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to delete command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainDelete : ReqBase, ICommandArgs<ReqDomainDelete>, IEppExtension, IVerisignNameStore
    {
        /// <summary>
        /// Initializes a new instance of the DomainDeleteArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Deleting domain name</param>
        public ReqDomainDelete(string domainName)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            this.DomainName = domainName;

        }

        public bool NicTrIsDomainCancel { get; set; }

        /// <summary>
        /// Initializes a new instance of the DomainDeleteArgs class
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReqDomainDelete()
        {
        }

        /// <summary>
        /// Gets deleting domain name
        /// </summary>
        public string DomainName { get; set; }

        public string TicketNumber { get; set; }

        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }

        #region ICommandArgs<DomainDeleteArgs> Members

        /// <summary>
        /// Fill delete command with domain delete content
        /// </summary>
        /// <param name="command">Delete command</param>
        public void FillCommand(ICommand command)
        {
            var domainNameElem = new XElement(MessageBase.DomainNs.GetName("name"), this.DomainName);
            var domainDeleteElement = new XElement(MessageBase.DomainNs.GetName("delete"), domainNameElem);
            domainDeleteElement.AddDomainSchemaLocation();
            command.GetCommandElement().Add(domainDeleteElement);
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        void IEppExtension.Extract(XElement objectElement)
        {
            this.DomainName = objectElement.Element(MessageBase.DomainNs.GetName("name")).Value;
        }

        #endregion


    }


}