using System;
using System.Linq;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Reperesents a data for the create command
    /// </summary>
    [Serializable]
    public class ResContactCreate : ICommandResult<ResContactCreate>
    {
        /// <summary>
        /// Gets desired server-unique identifier for the contact to be created
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets date and time of contact object creation
        /// </summary>
        public DateTime CreateDate { get; set; }

        public bool IsContactCreate { get; set; }

        #region ICommandResult<ContactCreateResult> members

        /// <summary>
        /// Extracts result from underlying create response
        /// </summary>
        /// <param name="response">Create response</param>
        public void ExtractResult(ResponseBase<ResContactCreate> response)
        {
            var createDataElement = response.GetResultElement();
            this.Id = createDataElement
                .Elements()
                .Where(el => el.Name.LocalName == "id")
                .FirstOrDefault()
                .Value;
            this.CreateDate = DateTime.Parse(createDataElement
                .Elements()
                .Where(el => el.Name.LocalName == "crDate")
                .FirstOrDefault()
                .Value).ToUniversalTime();
        }

        #endregion
    }
}
