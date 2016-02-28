using System;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to info command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactInfo : ContactAuthIDBase, ICommandArgs<ReqContactInfo, ResContactInfo>
    {
        /// <summary>
        /// Initializes a new instance of the ContactInfoArgs class
        /// </summary>
        /// <param name="id">Contact identifier</param>
        /// <param name="authInfo">Contact authentication information</param>
        public ReqContactInfo(string id, AuthInfo authInfo)
            : base(id, authInfo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContactInfoArgs class
        /// </summary>
        /// <param name="id">Contact identifier</param>
        public ReqContactInfo(string id)
            : base(id, null)
        {
        }

        public ReqContactInfo()
        {
        }

        #region ICommandArgs<ContactInfoArgs, ContactInfoResult> members

        /// <summary>
        /// Fill info command with contact info content
        /// </summary>
        /// <param name="command">Info command</param>
        public void FillCommand(ICommand command)
        {
            var contactInfoElement = new XElement(SchemaHelper.ContactNs.GetName("info"));
            contactInfoElement.AddContactSchemaLocation();
              //MessageBase.ContactNs + "info",
              //new XAttribute(XNamespace.Xmlns + "contact", "urn:ietf:params:xml:ns:contact-1.0"));
            FillObjectElement(contactInfoElement);
            command.GetCommandElement().Add(contactInfoElement);
        }

        #endregion       

        public string DomainName { get; set; }
    }
}
