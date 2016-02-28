using System;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Hosts;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Represents info command for hosts
    /// </summary>
    [Serializable]
    public class ReqHostInfo : ReqBase, ICommandArgs<ReqHostInfo, ResHostInfo>
    {
        /// <summary>
        /// Initializes a new instance of the HostInfoArgs class
        /// </summary>
        /// <param name="name">Fully qualified name of the host object</param>
        public ReqHostInfo(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;
        }

        public ReqHostInfo()
        {
        }

        /// <summary>
        /// Gets the fully qualified name of the host object
        /// </summary>
        public string Name { get; set; }

        #region ICommandArgs<HostInfoArgs, HostInfoResult> Members

        /// <summary>
        /// Fill info command with host info content
        /// </summary>
        /// <param name="command">Info command</param>
        public void FillCommand(ICommand command)
        {
            var resElement = new XElement(MessageBase.HostNs.GetName("info"));
            var nameElement = new XElement(MessageBase.HostNs.GetName("name"), this.Name);
            resElement.Add(nameElement);
            resElement.AddHostSchemaLocation();
            command.GetCommandElement().Add(resElement);
        }

        #endregion

        public string DomainName { get; set; }
    }
}