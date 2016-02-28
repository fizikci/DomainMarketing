using System;
using System.ComponentModel;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Request
{
    /// <summary>
    /// Object passed to delete command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactDelete : ReqBase, ICommandArgs<ReqContactDelete>, IEppExtension
    {
        /// <summary>
        /// Initializes a new instance of the ContactDeleteArgs class with specified contact identifier
        /// </summary>
        /// <param name="contactId">Deleting contact identifier</param>
        public ReqContactDelete(string contactId)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException("contactId");
            }

            this.ContactId = contactId;
        }

                /// <summary>
        /// Initializes a new instance of the ContactDeleteArgs class
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReqContactDelete()
        {
        }

        /// <summary>
        /// Gets deleting contact identifier
        /// </summary>
        public string ContactId { get; set; }

        #region ICommandArgs<ContactDeleteArgs> Members

        /// <summary>
        /// Fill delete command with contact delete content
        /// </summary>
        /// <param name="command">Delete command</param>
        public void FillCommand(ICommand command)
        {
            var contactIdElem = new XElement(MessageBase.ContactNs.GetName("id"), this.ContactId);
            var contactDeleteElement = new XElement(MessageBase.ContactNs.GetName("delete"), contactIdElem);
            contactDeleteElement.AddContactSchemaLocation();
            command.GetCommandElement().Add(contactDeleteElement);
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from specified object XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        void IEppExtension.Extract(XElement objectElement)
        {
            this.ContactId = objectElement.Element(MessageBase.ContactNs.GetName("id")).Value;
        }

        #endregion

        public string DomainName { get; set; }
    }
}