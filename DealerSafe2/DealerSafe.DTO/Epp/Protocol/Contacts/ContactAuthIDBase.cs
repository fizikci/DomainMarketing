using DealerSafe.DTO.Epp.Request;

namespace Epp.Protocol.Contacts
{
    using System;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Base class for contact info and transfer commands
    /// </summary>
    [Serializable]
    public class ContactAuthIDBase : ReqBase
    {
        /// <summary>
        /// Initializes a new instance of the ContactAuthIDBase class
        /// </summary>
        /// <param name="id">Contact identifier</param>
        /// <param name="authInfo">Contact authentication information</param>
        public ContactAuthIDBase(string id, AuthInfo authInfo)
        {
            this.AuthInfo = authInfo;
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }

        public ContactAuthIDBase()
        {
        }

        /// <summary>
        /// Gets contact identifier
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets contact authentication information
        /// </summary>
        public AuthInfo AuthInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Fill object XML element (contact info or contact transfer element) with contact Id and Auth content
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        protected void FillObjectElement(XElement objectElement)
        {
            var idElement = new XElement(MessageBase.ContactNs.GetName("id"), this.Id);
            objectElement.Add(idElement);
            if (this.AuthInfo != null)
            {
                var authInfoElement = new XElement(SchemaHelper.ContactNs.GetName("authInfo"));
                this.AuthInfo.Fill(authInfoElement);
                objectElement.Add(authInfoElement);
            }

            //objectElement.AddContactSchemaLocation();
        }
    }
}
