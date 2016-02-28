using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to check command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactCheck : ReqBase, ICommandArgs<ReqContactCheck, ResContactCheck>
    {
        /// <summary>
        /// Initializes a new instance of the ContactCheckArgs class
        /// </summary>
        /// <param name="contactIDs">Contact IDs for check</param>
        public ReqContactCheck(List<string> contactIDs)
        {
            if (contactIDs == null)
            {
                throw new ArgumentNullException("contactIDs");
            }

            var contIds = contactIDs.ToList();
            if (contIds.Count == 0)
            {
                throw new ArgumentException("contactIDs must be not empty sequence");
            }

            this.ContactIDs = contIds;
        }

        public ReqContactCheck()
        {
        }

        /// <summary>
        /// Gets contact IDs for check
        /// </summary>
        public List<string> ContactIDs { get; set; }

        #region ICommandArgs<ContactCheckArgs, ContactCheckResult> Members

        /// <summary>
        /// Fill check command with contact check content
        /// </summary>
        /// <param name="command">Check command</param>
        public void FillCommand(ICommand command)
        {
            XNamespace contactNs = MessageBase.ContactNs;
            var contactCheckElement = new XElement(SchemaHelper.ContactNs.GetName("check"));
                //  contactNs + "check", new XAttribute(XNamespace.Xmlns + "contact", contactNs.NamespaceName));
            foreach (var contactId in ContactIDs)
            {
                contactCheckElement.Add(new XElement(contactNs + "id",contactId));
            }
            contactCheckElement.AddContactSchemaLocation();
            command.GetCommandElement().Add(contactCheckElement);
        }

        #endregion

        public string DomainName { get; set; }
    }
}