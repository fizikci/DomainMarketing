using System;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to update command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactUpdate : ReqBase, ICommandArgs<ReqContactUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the ContactUpdateArgs class with specified contact identifier
        /// </summary>
        /// <param name="contactId">Updating contact identifier</param>
        public ReqContactUpdate(string contactId)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException("contactId");
            }

            this.ContactId = contactId;
        }

        public ReqContactUpdate()
        {
        }

        /// <summary>
        /// Gets updating contact identifier
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or sets contact adding information
        /// </summary>
        public ContactAddRemType Add { get; set; }

        /// <summary>
        /// Gets or sets contact removing information
        /// </summary>
        public ContactAddRemType Rem { get; set; }

        /// <summary>
        /// Gets or sets contact changing information
        /// </summary>
        public ContactChangeType Chg { get; set; }

        #region ICommandArgs<ContactUpdateArgs> Members

        /// <summary>
        /// Fill update command with contact update content
        /// </summary>
        /// <param name="command">Update command</param>
        public void FillCommand(ICommand command)
        {
            var contactIdElem = new XElement(MessageBase.ContactNs.GetName("id"), this.ContactId);
            var contactUpdateElement = new XElement(MessageBase.ContactNs.GetName("update"), contactIdElem);
            if (this.Add != null)
            {
                var addElem = new XElement(SchemaHelper.ContactNs.GetName("add"));
                this.Add.Fill(addElem);
                contactUpdateElement.Add(addElem);
            }

            if (this.Rem != null)
            {
                var remElem = new XElement(SchemaHelper.ContactNs.GetName("rem"));
                this.Rem.Fill(remElem);
                contactUpdateElement.Add(remElem);
            }

            if (this.Chg != null)
            {
                var chgElem = new XElement(SchemaHelper.ContactNs.GetName("chg"));
                this.Chg.Fill(chgElem);
                contactUpdateElement.Add(chgElem);
            }

            contactUpdateElement.AddContactSchemaLocation();
            command.GetCommandElement().Add(contactUpdateElement);
        }

        #endregion

        public string DomainName { get; set; }
    }
}
