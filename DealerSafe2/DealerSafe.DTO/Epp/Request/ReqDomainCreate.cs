using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to create command for domains
    /// </summary>
    [Serializable]
    public class ReqDomainCreate : ReqBase, ICommandArgs<ReqDomainCreate, ResDomainCreate>, IVerisignNameStore
    {
        /// <summary>
        /// Domain contacts
        /// </summary>
        private List<DomainContactInfo> contacts;

        /// <summary>
        /// Initializes a new instance of the DomainCreateArgs class with specified domain name
        /// </summary>
        /// <param name="domainName">Creating domain name</param>
        /// <param name="auth">Creating domain authentication info</param>
        public ReqDomainCreate(string domainName, AuthInfo auth)
        {
            if (domainName == null)
            {
                throw new ArgumentNullException("domainName");
            }

            if (auth == null)
            {
                throw new ArgumentNullException("auth");
            }

            this.DomainName = domainName;
            this.AuthInfo = auth;
        }

        public ReqDomainCreate()
        {
        }

        /// <summary>
        /// Gets creating domain name
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets domain registration period in the count of monthes
        /// </summary>
        public DomainPeriod RegistrationPeriod { get; set; }

        /// <summary>
        /// Gets or sets name server list
        /// </summary>
        public NameServerList NameServers { get; set; }

        /// <summary>
        /// Gets or sets registrant's contact identifier
        /// </summary>
        public string Registrant { get; set; }

        /// <summary>
        /// Gets or sets domain contacts
        /// </summary>
        public List<DomainContactInfo> Contacts
        {
            get
            {
                return this.contacts;
            }

            set
            {
                this.contacts = (value ?? Enumerable.Empty<DomainContactInfo>()).ToList();
            }
        }

        /// <summary>
        /// Gets authentication information for creating domain
        /// </summary>
        public AuthInfo AuthInfo { get; set; }

        public Protocol.Launch.createType ExtLaunch { get; set; }
        public Protocol.KeySys.createType ExtKeySys { get; set; }
        public Protocol.NameStore.namestoreExtType ExtNameStore { get; set; }

        public string DirectiAttributes { get; set; }

        #region ICommandArgs<DomainCreateArgs, DomainCreateResult> Members

        /// <summary>
        /// Fills create command with domain create content
        /// </summary>
        /// <param name="command">Create command</param>
        public void FillCommand(ICommand command)
        {
            var createElement = command.GetCommandElement();

            var nameElem = new XElement(SchemaHelper.DomainNs.GetName("name"), this.DomainName);

            var domainCreateElement = new XElement(SchemaHelper.DomainNs.GetName("create"), nameElem);

            if (this.RegistrationPeriod != null)
            {
                var periodElem = new XElement(SchemaHelper.DomainNs.GetName("period"));
                this.RegistrationPeriod.Fill(periodElem);
                domainCreateElement.Add(periodElem);
            }

            if (this.NameServers != null && this.NameServers.Any())
            {
                var nameServersElem = new XElement(SchemaHelper.DomainNs.GetName("ns"));
                this.NameServers.Fill(nameServersElem);
                domainCreateElement.Add(nameServersElem);
            }

            if (!String.IsNullOrEmpty(this.Registrant))
            {
                var registrantElem = new XElement(SchemaHelper.DomainNs.GetName("registrant"), this.Registrant);
                domainCreateElement.Add(registrantElem);
            }

            if (this.Contacts != null && this.Contacts.Any())
            {
                var contactsElems = this.Contacts
                    .Select(contact =>
                            {
                                var contactElem = new XElement(SchemaHelper.DomainNs.GetName("contact"));
                                contact.Fill(contactElem);
                                return contactElem;
                            });
                domainCreateElement.Add(contactsElems);
            }

            var authInfoElem = new XElement(SchemaHelper.DomainNs.GetName("authInfo"));
            this.AuthInfo.Fill(authInfoElem);
            domainCreateElement.Add(authInfoElem);

            domainCreateElement.AddDomainSchemaLocation();
            createElement.Add(domainCreateElement);
        }

        #endregion


        // NicTR
        public bool IsNameSurnameDomain { get; set; }

        public NicTrSelectedContact NicTrSelectedContact { get; set; }

    }

    public class NicTrSelectedContact
    {
        public string Name { get; set; }
        public string CitizenId { get; set; }
        public string Organization { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string MemberType { get; set; }
    }
}