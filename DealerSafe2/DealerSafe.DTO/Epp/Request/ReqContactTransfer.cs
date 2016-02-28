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
    /// Object passed to transfer command for contacts
    /// </summary>
    [Serializable]
    public class ReqContactTransfer : ContactAuthIDBase, ICommandArgs<ReqContactTransfer, ResContactTransfer>
    {
        /// <summary>
        /// Initializes a new instance of the ContactTransferArgs class
        /// </summary>
        /// <param name="id">Contact identifier</param>
        /// <param name="authInfo">Contact authentication transferrmation</param>
        public ReqContactTransfer(string id, AuthInfo authInfo)
            : base(id, authInfo)
        {
        }

        public ReqContactTransfer()
        {
        }

        #region ICommandArgs<ContactTransferArgs, ContactTransferResult> members

        /// <summary>
        /// Fill transfer command with contact transfer content
        /// </summary>
        /// <param name="command">Transfer command</param>
        public void FillCommand(ICommand command)
        {
            var contactTransferElement = new XElement(MessageBase.ContactNs.GetName("transfer"));
            FillObjectElement(contactTransferElement);
            contactTransferElement.AddContactSchemaLocation();
            command.GetCommandElement().Add(contactTransferElement);
        }

        #endregion

        public string DomainName { get; set; }
    }

    public class ReqContactTransferApprove : ReqContactTransfer
    {
    }
    public class ReqContactTransferCancel : ReqContactTransfer
    {
    }
    public class ReqContactTransferQuery : ReqContactTransfer
    {
    }
    public class ReqContactTransferReject : ReqContactTransfer
    {
    }
    public class ReqContactTransferRequest : ReqContactTransfer
    {
    }
}
