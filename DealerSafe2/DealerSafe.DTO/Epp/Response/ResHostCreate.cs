using System;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for host create command
    /// </summary>
    [Serializable]
    public class ResHostCreate : ICommandResult<ResHostCreate>
    {
        /// <summary>
        /// Gets host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets host creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        public string DirectiActionStatusDescription { get; set; }

        #region ICreateData<HostCreateData> Members

        /// <summary>
        /// Extracts result from underlying create response
        /// </summary>
        /// <param name="response">Create response</param>
        public void ExtractResult(ResponseBase<ResHostCreate> response)
        {
            XElement creDataElem = response.GetResultElement();
            this.HostName = creDataElem.Element(SchemaHelper.HostNs.GetName("name")).Value;
            this.CreateDate = DateTime.Parse(creDataElem.Element(SchemaHelper.HostNs.GetName("crDate")).Value).ToUniversalTime();
        }

        #endregion
    }
}