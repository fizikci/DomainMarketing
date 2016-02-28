using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Xml.Linq;
using launch = DealerSafe.DTO.Epp.Protocol.Launch;
using premium = DealerSafe.DTO.Epp.Protocol.PremiumDomain;
using balance = DealerSafe.DTO.Epp.Protocol.Balance;
using rgp = DealerSafe.DTO.Epp.Protocol.Rgp;
using keySys = DealerSafe.DTO.Epp.Protocol.KeySys;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Represents the info data for the domain
    /// </summary>
    [Serializable]
    public class ResDomainInfo : CommandResult<ResDomainInfo>, IEppExtension
    {
        /// <summary>
        /// Gets domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets domain name
        /// </summary>
        public string ROID { get; set; }

        /// <summary>
        /// Gets the list of domain statuses
        /// </summary>
        public List<StatusInfo> Statuses { get; set; }

        /// <summary>
        /// Gets domain registrant
        /// </summary>
        public string Registrant { get; set; }

        /// <summary>
        /// Gets the list of domain contacts
        /// </summary>
        public List<DomainContactInfo> Contacts { get; set; }

        /// <summary>
        /// Gets domain names servers
        /// </summary>
        public NameServerList NameServers { get; set; }

        /// <summary>
        /// Gets domain hosts
        /// </summary>
        public List<string> Hosts { get; set; }

        /// <summary>
        /// Gets sponsoring client identifier
        /// </summary>
        public string SponsoringClientId { get; set; }

        /// <summary>
        /// Gets creator client identifier
        /// </summary>
        public string CreatorClientId { get; set; }

        /// <summary>
        /// Gets domain creation date if any
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets domain authentication info if any
        /// </summary>
        public AuthInfo AuthInfo { get; set; }

        /// <summary>
        /// Gets domain transfer date if any
        /// </summary>
        public DateTime? TransferDate { get; set; }

        /// <summary>
        /// Gets domain last update date if any
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets updater client identifier if any
        /// </summary>
        public string UpdaterClientId { get; set; }

        /// <summary>
        /// Gets domain expriration date if any
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        public string StrExpirationDate { get; set; }

        public string NicTrTicketStatus { get; set; }

        public launch.infDataType ExtLaunch { get; set; }
        public rgp.respDataType ExtRgp { get; set; }
        public keySys.resDataType ExtKeySys { get; set; }

        /// <summary>
        /// Extracts result from underlying info response
        /// </summary>
        /// <param name="response">Info response</param>
        public override void ExtractResult(ResponseBase<ResDomainInfo> response)
        {
            base.ExtractResult(response);
            this.Extract(response.GetResultElement());
        }

        public string DirectiLocks { get; set; }
        public List<DirectiDomainCnsInfo> DirectiDomainCns { get; set; }
        public string DirectiCurrentStatus { get; set; }
        public List<string> DirectiDomainStatus { get; set; }
        public string DirectiOrderId { get; set; }
        public string DirectiCustomerId { get; set; }

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        public void Extract(XElement objectElement)
        {
            this.DomainName = objectElement.Element(SchemaHelper.DomainNs.GetName("name")).Value;
            this.ROID = objectElement.Element(SchemaHelper.DomainNs.GetName("roid")).Value;
            this.Statuses = objectElement
                .Elements(SchemaHelper.DomainNs.GetName("status"))
                .Select(statusElem =>
                {
                    var status = EnumParser.ToEnum<Status>((string)statusElem.Attribute("s").Value);
                    var statusText = statusElem.Value;
                    var langAttribute = statusElem.Attribute("lang");
                    var lang = langAttribute == null ? "en" : langAttribute.Value;
                    return new StatusInfo(status, statusText, lang);
                })
                .ToList();

            var registrantElem = objectElement.Element(SchemaHelper.DomainNs.GetName("registrant"));
            this.Registrant = registrantElem == null ? null : registrantElem.Value;

            this.Contacts = objectElement
                .Elements(SchemaHelper.DomainNs.GetName("contact"))
                .Select(contactElem => DomainContactInfo.Extract(contactElem))
                .ToList();

            var nameServersElement = objectElement.Element(SchemaHelper.DomainNs.GetName("ns"));
            this.NameServers = nameServersElement != null ? NameServerList.Extract(nameServersElement) : new NameServerList();

            this.Hosts = objectElement.Elements(SchemaHelper.DomainNs.GetName("host")).Select(elem => elem.Value).ToList();

            this.SponsoringClientId = objectElement.Element(SchemaHelper.DomainNs.GetName("clID")).Value;

            var creatorIDElem = objectElement.Element(SchemaHelper.DomainNs.GetName("crID"));
            this.CreatorClientId = creatorIDElem == null ? null : creatorIDElem.Value;

            var creationDateElem = objectElement.Element(SchemaHelper.DomainNs.GetName("crDate"));
            this.CreationDate = creationDateElem == null ? (DateTime?)null : DateTime.Parse(creationDateElem.Value).ToUniversalTime();

            var expirationDateElem = objectElement.Element(SchemaHelper.DomainNs.GetName("exDate"));
            this.ExpirationDate = expirationDateElem == null ? (DateTime?)null : DateTime.Parse(expirationDateElem.Value).ToUniversalTime();

            var updaterIDElem = objectElement.Element(SchemaHelper.DomainNs.GetName("upID"));
            this.UpdaterClientId = updaterIDElem == null ? null : updaterIDElem.Value;

            var updateDateElem = objectElement.Element(SchemaHelper.DomainNs.GetName("upDate"));
            this.UpdateDate = updateDateElem == null ? (DateTime?)null : DateTime.Parse(updateDateElem.Value).ToUniversalTime();

            var transDateElem = objectElement.Element(SchemaHelper.DomainNs.GetName("trDate"));
            this.TransferDate = transDateElem == null ? (DateTime?)null : DateTime.Parse(transDateElem.Value).ToUniversalTime();

            var authInfoElem = objectElement.Element(SchemaHelper.DomainNs.GetName("authInfo"));
            if (authInfoElem != null)
            {
                this.AuthInfo = AuthInfo.Extract(authInfoElem);
            }
        }

        #endregion

        public bool IsRegistrarFBS()
        {
            if (this.CreatorClientId != null)
            {
                return this.CreatorClientId.Contains("6116-FB") ||
                       this.CreatorClientId.Contains("1-ZS2H2") ||
                       this.CreatorClientId.Contains("fbs") ||
                       this.CreatorClientId.Contains("fbs-1110") ||
                       this.CreatorClientId.Contains("1110") ||
                       this.CreatorClientId.Contains("isimtescil") ||
                       this.CreatorClientId.Contains("4116-FB") ||
                       this.CreatorClientId.Contains("H3693396");

            }
            else if (this.SponsoringClientId != null)
            {
                return this.SponsoringClientId.Contains("6116-FB") ||
                       this.SponsoringClientId.Contains("1-ZS2H2") ||
                       this.SponsoringClientId.Contains("fbs") ||
                       this.SponsoringClientId.Contains("fbs-1110") ||
                       this.SponsoringClientId.Contains("1110") ||
                       this.SponsoringClientId.Contains("isimtescil") ||
                       this.SponsoringClientId.Contains("4116-FB") ||
                       this.SponsoringClientId.Contains("H3693396");

            }
            else
                return false;



        }
    }

    [Serializable]
    public class DirectiDomainCnsInfo
    {
        public string CnsName { get; set; }
        public string CnsIp { get; set; }
    }
}