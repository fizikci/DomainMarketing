using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Reperesents a data for the info command
    /// </summary>
    [Serializable]
    public class ResContactInfo : CommandResult<ResContactInfo>, IEppExtension
    {
        /// <summary>
        /// Gets the server-unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the Repository Object IDentifier
        /// </summary>
        public string Roid { get; set; }

        /// <summary>
        /// Gets status
        /// </summary>
        public List<StatusInfo> Status { get; set; }

        /// <summary>
        /// Gets postal information
        /// </summary>
        public List<PostalInfo> PostalInfos { get; set; }

        /// <summary>
        /// Gets the voice telephone number
        /// </summary>
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Gets the facsimile telephone number
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets the contact's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the identifier of the sponsoring client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets the identifier of the client that created the contact
        /// </summary>
        public string CreateId { get; set; }

        /// <summary>
        /// Gets the identifier of the client that created the contact object
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

        /// <summary>
        /// Gets authorization information associated with the contact object
        /// </summary>
        public AuthInfo Auth { get; set; }

        /// <summary>
        /// Gets disclose
        /// </summary>
        public Disclose Disclose { get; set; }


        public string StrNicTrContactInfo { get; set; }

        /// <summary>
        /// Extracts result from underlying check response
        /// </summary>
        /// <param name="response">Info response</param>
        public override void ExtractResult(ResponseBase<ResContactInfo> response)
        {
            base.ExtractResult(response);
            this.Extract(response.GetResultElement());
        }

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        public void Extract(XElement objectElement)
        {
            this.Id = objectElement.Element(SchemaHelper.ContactNs.GetName("id")).Value;
            this.Roid = objectElement.Element(SchemaHelper.ContactNs.GetName("roid")).Value;

            this.Status = objectElement
                .Elements(SchemaHelper.ContactNs.GetName("status"))
                .Select(status => StatusInfo.Extract(status))
                .ToList();

            this.PostalInfos = objectElement.Elements(SchemaHelper.ContactNs.GetName("postalInfo"))
                .Select(pos => PostalInfo.Extract(pos))
                .ToList();

            this.Voice = objectElement
                .Elements(SchemaHelper.ContactNs.GetName("voice"))
                .Select(voice => VoiceInfo.Extract(voice))
                .FirstOrDefault();

            this.Fax = objectElement
                .Elements(SchemaHelper.ContactNs.GetName("fax"))
                .Select(fax => fax.Value)
                .FirstOrDefault();
            var email = objectElement.Element(SchemaHelper.ContactNs.GetName("email"));
            this.Email = email == null ? null : email.Value;

            var clientId = objectElement.Element(SchemaHelper.ContactNs.GetName("clID"));
            this.ClientId = clientId == null ? null : clientId.Value;

            var creadteId = objectElement.Element(SchemaHelper.ContactNs.GetName("crID"));
            this.CreateId = creadteId == null ? null : creadteId.Value;

            var createDate = objectElement.Element(SchemaHelper.ContactNs.GetName("crDate"));
            this.CreateDate = createDate == null ? (DateTime?)null : DateTime.Parse(createDate.Value).ToUniversalTime();

            var updateIdElement = objectElement.Element(SchemaHelper.ContactNs.GetName("upID"));
            this.UpdateId = updateIdElement == null ? null : updateIdElement.Value;

            var updateDateElement = objectElement.Element(SchemaHelper.ContactNs.GetName("upDate"));
            this.UpdateDate = updateDateElement == null ? (DateTime?)null : DateTime.Parse(updateDateElement.Value).ToUniversalTime();

            var transferDateElement = objectElement.Element(SchemaHelper.ContactNs.GetName("trDate"));
            this.TransferDate = transferDateElement == null ? (DateTime?)null : DateTime.Parse(transferDateElement.Value).ToUniversalTime();

            this.Auth = objectElement
                .Elements(SchemaHelper.ContactNs.GetName("authInfo"))
                .Select(authInfo => AuthInfo.Extract(authInfo))
                .FirstOrDefault();

            this.Disclose = objectElement
                .Elements(SchemaHelper.ContactNs.GetName("disclose"))
                .Select(dis =>
                {
                    bool discloseFlag;
                    if (!Boolean.TryParse(dis.Attribute("flag").Value, out discloseFlag))
                    {
                        discloseFlag = Int32.Parse(dis.Attribute("flag").Value) != 0;
                    }

                    var disclose = new Disclose(discloseFlag);

                    if (dis.Elements() != null)
                    {
                        var elements = new List<string>();
                        foreach (var element in dis.Elements())
                        {
                            elements.Add(element.Name.LocalName);
                        }

                        disclose.DisclosingFields = elements;
                    }

                    return disclose;
                })
                .FirstOrDefault();
        }

        #endregion
    }
}