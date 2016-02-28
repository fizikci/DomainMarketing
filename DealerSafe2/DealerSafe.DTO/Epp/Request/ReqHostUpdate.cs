using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Hosts;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to update command for hosts
    /// </summary>
    [Serializable]
    public class ReqHostUpdate : ReqBase, ICommandArgs<ReqHostUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the HostUpdateArgs class
        /// </summary>
        /// <param name="hostName">Updating host name</param>
        public ReqHostUpdate(string hostName)
        {
            if (String.IsNullOrEmpty(hostName))
            {
                throw new ArgumentNullException();
            }

            this.HostName = hostName;
        }

        public ReqHostUpdate()
        {
        }

        /// <summary>
        /// Gets or sets updating host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets adding information
        /// </summary>
        public HostAddRemType Add { get; set; }

        /// <summary>
        /// Gets or sets removing information
        /// </summary>
        public HostAddRemType Rem { get; set; }

        /// <summary>
        /// Gets or sets object contains a new fully qualified host 
        /// name by which the host object will be known
        /// </summary>
        public string Chg { get; set; }

        #region ICommandArgs<HostUpdateArgs> Members

        /// <summary>
        /// Fill update command with host update content
        /// </summary>
        /// <param name="command">Update command</param>
        public void FillCommand(ICommand command)
        {
            var hostNameElem = new XElement(MessageBase.HostNs.GetName("name"), this.HostName);
            var hostUpdateElement = new XElement(MessageBase.HostNs.GetName("update"), hostNameElem);

            if (this.Add != null)
            {
                var addElem = new XElement(MessageBase.HostNs.GetName("add"));
                this.Add.Fill(addElem);
                hostUpdateElement.Add(addElem);
            }

            if (this.Rem != null)
            {
                var remElem = new XElement(MessageBase.HostNs.GetName("rem"));
                this.Rem.Fill(remElem);
                hostUpdateElement.Add(remElem);
            }

            if (this.Chg != null)
            {
                var chgElem = new XElement(MessageBase.HostNs.GetName("chg"));
                var nameElem = new XElement(MessageBase.HostNs.GetName("name"), this.Chg);
                chgElem.Add(nameElem);
                hostUpdateElement.Add(chgElem);
            }

            hostUpdateElement.AddHostSchemaLocation();
            command.GetCommandElement().Add(hostUpdateElement);
        }

        #endregion

        public string DomainName { get; set; }


        public string DirectiOldCns { get; set; }


        public string DirectiNewCns { get; set; }


        public string DirectiOldIp { get; set; }


        public string DirectiNewIp { get; set; }
        
        public DirectiOperationTypes DirectiOperationType { get; set; }

        public NicTrOperationTypes NicTrOperationType { get; set; }


        public string NicTrNewCns { get; set; }

        public string NicTrNewIp { get; set; }

    }
}
