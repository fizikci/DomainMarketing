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
    /// Object passed to check command for hosts
    /// </summary>
    [Serializable]
    public class ReqHostCheck : ReqBase, ICommandArgs<ReqHostCheck, ResHostCheck>
    {
        /// <summary>
        /// Initializes a new instance of the HostCheckArgs class
        /// </summary>
        /// <param name="hostNames">Domain names for check</param>
        public ReqHostCheck(List<string> hostNames)
        {
            if (hostNames == null)
            {
                throw new ArgumentNullException("hostNames");
            }

            var hostNamesList = hostNames.ToList();
            if (hostNamesList.Count == 0)
            {
                throw new ArgumentException("hostNames must be not empty sequence");
            }

            this.HostNames = hostNamesList;
        }

        public ReqHostCheck()
        {
        }

        /// <summary>
        /// Gets host names for check
        /// </summary>
        public List<string> HostNames { get; set; }

        #region ICommandArgs<HostCheckArgs, HostCheckResult> Members

        /// <summary>
        /// Fill check command with host check content
        /// </summary>
        /// <param name="command">Check command</param>
        public void FillCommand(ICommand command)
        {
            var hostNs = MessageBase.HostNs;
            var hostCheckElement = new XElement(SchemaHelper.HostNs.GetName("check"));

            //var hostCheckElement = new XElement(hostNs + "check",
            //                                    new XAttribute(XNamespace.Xmlns + "host",
            //                                                   hostNs.NamespaceName));

            foreach (var hostName in HostNames)
            {
                hostCheckElement.Add(new XElement(hostNs + "name", hostName));
            }
            hostCheckElement.AddHostSchemaLocation();
            command.GetCommandElement().Add(hostCheckElement);
        }

        #endregion

        public string DomainName { get; set; }
    }
}