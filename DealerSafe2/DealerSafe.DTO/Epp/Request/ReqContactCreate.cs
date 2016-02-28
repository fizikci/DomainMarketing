using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to create command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactCreate : ReqBase, ICommandArgs<ReqContactCreate, ResContactCreate>
    {
        /// <summary>
        /// Initializes a new instance of the ContactCreateArgs class
        /// </summary>
        /// <param name="contactId">Desired server-unique identifier for the contact to be created</param>
        /// <param name="postalInfos">One or two elements that contain postal address information</param>
        /// <param name="email">Contact's email address</param>
        /// <param name="authInfo">Authorization information to be associated with the contact object</param>
        public ReqContactCreate(string contactId, List<PostalInfo> postalInfos, string email, AuthInfo authInfo)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException("contactId");
            }

            if (postalInfos == null)
            {
                throw new ArgumentNullException("postalInfos");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            ////if (auth == null)
            ////{
            ////    throw new ArgumentNullException("auth");
            ////}

            this.ContactId = contactId;
            this.Postals = postalInfos.ToList();
            this.Email = email;
            this.AuthInfo = authInfo;
        }

        public ReqContactCreate()
        {
        }

        /// <summary>
        /// Gets the desired server-unique identifier for the contact to be created
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets postal address information
        /// </summary>
        public List<PostalInfo> Postals { get; set; }

        /// <summary>
        /// Gets or sets the contact's voice telephone number
        /// </summary>
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Gets or sets contact's facsimile telephone number.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets the contact's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets authorization information to be associated with the contact object
        /// </summary>
        public AuthInfo AuthInfo { get; set; }

        /// <summary>
        /// Gets or sets the element that allows a client to identify elements that require exceptional server operator
        /// handling to allow or restrict disclosure to third parties
        /// </summary>
        public Disclose Disclose { get; set; }

        #region ICommandArgs<ContactCreateArgs, ContactCreateResult>

        /// <summary>
        /// Fill info command with contact info content
        /// </summary>
        /// <param name="command">Info command</param>
        public void FillCommand(ICommand command)
        {
            var resElement = new XElement(MessageBase.ContactNs.GetName("create"));
            var idElement = new XElement(MessageBase.ContactNs.GetName("id"), this.ContactId);
            resElement.Add(idElement);
            foreach (var postal in this.Postals)
            {
                var postalElement = new XElement(SchemaHelper.ContactNs.GetName("postalInfo"));
                postal.Fill(postalElement);
                resElement.Add(postalElement);
            }

            if (this.Voice != null)
            {
                var voiceElement = new XElement(SchemaHelper.ContactNs.GetName("voice"));
                this.Voice.Fill(voiceElement);
                resElement.Add(voiceElement);
            }

            if (this.Fax != null)
            {
                resElement.Add(new XElement(SchemaHelper.ContactNs.GetName("fax"), this.Fax));
            }

            resElement.Add(new XElement(SchemaHelper.ContactNs.GetName("email"), this.Email));

            var authInfo = this.AuthInfo ?? new AuthInfo(null);
            var authElement = new XElement(SchemaHelper.ContactNs.GetName("authInfo"));
            authInfo.Fill(authElement);
            resElement.Add(authElement);

            if (this.Disclose != null)
            {
                var discloseElement = new XElement(SchemaHelper.ContactNs.GetName("disclose"));
                this.Disclose.Fill(discloseElement);
                resElement.Add(discloseElement);
            }

            resElement.AddContactSchemaLocation();

            command.GetCommandElement().Add(resElement);
        }

        #endregion

        public string DomainName { get; set; }


        public string DirectiContactCreateAttributes { get; set; }

        public DirectiContactTypes DirectiContactType { get; set; }

        public string DirectiPhoneCountryCode { get; set; }

        public string DirectiCustomerId { get; set; }

        // NicTR
        public string NameSurname { get; set; }
        public string Organization { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CitizenId { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }


    }

    public enum DirectiContactTypes
    {
        Contact = 1,
        UkContact = 2,
        EuContact = 3,
        CnContact = 4,
        CoContact = 5,
        CaContact = 6,
        DeContact = 7,
        EsContact = 8
    }

    
}
