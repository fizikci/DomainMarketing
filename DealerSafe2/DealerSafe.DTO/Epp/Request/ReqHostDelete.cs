using System;
using System.ComponentModel;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to delete command for hosts
    /// </summary>
    [Serializable]
    public class ReqHostDelete : ReqBase, ICommandArgs<ReqHostDelete>, IEppExtension
    {
        /// <summary>
        /// Initializes a new instance of the HostDeleteArgs class with specified host name
        /// </summary>
        /// <param name="hostName">Deleting host name</param>
        public ReqHostDelete(string hostName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException("hostName");
            }

            this.HostName = hostName;
        }

        /// <summary>
        /// Initializes a new instance of the HostDeleteArgs class
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReqHostDelete()
        {
        }

        /// <summary>
        /// Gets deleting host name
        /// </summary>
        public string HostName { get; set; }

        #region ICommandArgs<HostDeleteArgs> Members

        /// <summary>
        /// Fill delete command with host delete content
        /// </summary>
        /// <param name="command">Delete command</param>
        public void FillCommand(ICommand command)
        {
            var hostNameElem = new XElement(MessageBase.HostNs.GetName("name"), this.HostName);
            var hostDeleteElement = new XElement(MessageBase.HostNs.GetName("delete"), hostNameElem);
            hostDeleteElement.AddHostSchemaLocation();
            command.GetCommandElement().Add(hostDeleteElement);
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        void IEppExtension.Extract(XElement objectElement)
        {
            this.HostName = objectElement.Element(MessageBase.HostNs.GetName("name")).Value;
        }

        #endregion

        public string DomainName { get; set; }

        public string DirectiIpAddress { get; set; }

    }
}