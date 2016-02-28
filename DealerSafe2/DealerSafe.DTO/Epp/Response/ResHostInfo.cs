using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Hosts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Represents the info data for the host
    /// </summary>
    [Serializable]
    public class ResHostInfo : ICommandResult<ResHostInfo>, IEppExtension
    {
        /// <summary>
        /// Gets or sets the fully qualified name of the host object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Repository Object IDentifier
        /// </summary>
        public string Roid { get; set; }

        /// <summary>
        /// Gets status
        /// </summary>
        public List<StatusInfo> Status { get; set; }

        /// <summary>
        /// Gets or sets IP addresses associated with the host object
        /// </summary>
        public List<IpAddress> IPAddress { get; set; }

        /// <summary>
        /// Gets the identifier of the client that created the contact object
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets the identifier of the client that created the host object.
        /// </summary>
        public string CreateId { get; set; }

        /// <summary>
        /// Gets the date and time of host object creation.
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Gets the identifier of the client that created the contact object
        /// </summary>
        public string UpdateId { get; set; }

        /// <summary>
        /// Gets the date and time of the most recent contact object modification
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets the date and time of the most recent successful contact object transfer
        /// </summary>
        public DateTime? TransferDate { get; set; }

        #region ICommandResult<HostInfoResult> Members

        /// <summary>
        /// Extracts result from underlying check response
        /// </summary>
        /// <param name="response">Check response</param>
        public void ExtractResult(ResponseBase<ResHostInfo> response)
        {
            this.Extract(response.GetResultElement());
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        public void Extract(XElement objectElement)
        {
            this.Name = GetValueByName(objectElement, "name");
            this.Roid = objectElement.Element(SchemaHelper.HostNs.GetName("roid")).Value;
            this.Status = objectElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "status")
                .Select(status => StatusInfo.Extract(status))
                .ToList();
            this.IPAddress = objectElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "addr")
                .Select(addr => IpAddress.Extract(addr))
                .ToList();

            var clientIdElem = objectElement.Element(SchemaHelper.HostNs.GetName("clID"));
            this.ClientId = clientIdElem == null ? null : clientIdElem.Value;

            var createIdElem = objectElement.Element(SchemaHelper.HostNs.GetName("crID"));
            this.CreateId = createIdElem == null ? null : createIdElem.Value;

            var crdDateElem = objectElement.Element(SchemaHelper.HostNs.GetName("crDate"));
            this.CreateDate = crdDateElem == null ? (DateTime?)null : DateTime.Parse(crdDateElem.Value).ToUniversalTime();

            var updIdElem = objectElement.Element(SchemaHelper.HostNs.GetName("upID"));
            this.UpdateId = updIdElem == null ? null : updIdElem.Value;

            var updDateElem = objectElement.Element(SchemaHelper.HostNs.GetName("upDate"));
            this.UpdateDate = updDateElem == null ? (DateTime?)null : DateTime.Parse(updDateElem.Value).ToUniversalTime();

            var tranDateElem = objectElement.Element(SchemaHelper.HostNs.GetName("trDate"));
            this.TransferDate = tranDateElem == null ? (DateTime?)null : DateTime.Parse(tranDateElem.Value).ToUniversalTime();
        }

        #endregion

        /// <summary>
        /// Gets the value of the XML element
        /// </summary>
        /// <param name="element">XML element</param>
        /// <param name="name">XMl element name</param>
        /// <returns>Value of the XML element</returns>
        private static string GetValueByName(XElement element, string name)
        {
            return element
                .Elements()
                .Where(el => el.Name.LocalName == name)
                .FirstOrDefault()
                .Value;
        }
    }
}
