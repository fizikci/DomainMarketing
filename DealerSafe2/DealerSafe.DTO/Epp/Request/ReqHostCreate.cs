using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Hosts;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to create command for hosts
    /// </summary>
    [Serializable]
    public class ReqHostCreate : ReqBase, ICommandArgs<ReqHostCreate, ResHostCreate>
    {
        /// <summary>
        /// Initializes a new instance of the HostCreateArgs class with specified host name and addresses
        /// </summary>
        /// <param name="hostName">Creating host name</param>
        /// <param name="hostAddreses">Creating host addresses</param>
        public ReqHostCreate(string hostName, List<IpAddress> hostAddreses)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException("hostName");
            }

            this.HostName = hostName;
            this.HostAddreses = (hostAddreses ?? Enumerable.Empty<IpAddress>()).ToList();
        }

        public ReqHostCreate()
        {
        }

        /// <summary>
        /// Gets host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets host addresses
        /// </summary>
        public List<IpAddress> HostAddreses { get; set; }

        #region ICommandArgs<HostCreateArgs, HostCreateResult> Members

        /// <summary>
        /// Fill create command with host create content
        /// </summary>
        /// <param name="command">Create command</param>
        public void FillCommand(ICommand command)
        {
            var nameElement = new XElement(SchemaHelper.HostNs.GetName("name"), this.HostName);

            var hostCreateElement = new XElement(MessageBase.HostNs.GetName("create"), nameElement);

            if (this.HostAddreses != null)
            {
                List<XElement> addressElements = this.HostAddreses
                                                     .Select(addr =>
                                                         {
                                                             var addrElem =
                                                                 new XElement(SchemaHelper.HostNs.GetName("addr"));
                                                             addr.Fill(addrElem);
                                                             return addrElem;
                                                         }).ToList();
                hostCreateElement.Add(addressElements);
            }

            hostCreateElement.AddHostSchemaLocation();
            command.GetCommandElement().Add(hostCreateElement);
        }

        #endregion

        public string DomainName { get; set; }
    }
}