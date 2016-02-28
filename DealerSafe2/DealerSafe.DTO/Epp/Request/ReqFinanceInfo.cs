using System;
using System.Xml.Linq;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Request
{

    [Serializable]
    public class ReqFinanceInfo : ReqBase, ICommandArgs<ReqFinanceInfo, ResFinanceInfo>
    {

        #region ICommandArgs<ContactInfoArgs, ContactInfoResult> members

        /// <summary>
        /// Fill info command with contact info content
        /// </summary>
        /// <param name="command">Info command</param>
        public void FillCommand(ICommand command)
        {
            var financeInfoElement = new XElement(SchemaHelper.FinanceNs.GetName("info"));
            financeInfoElement.AddFinanceSchemaLocation();
            command.GetCommandElement().Add(financeInfoElement);
        }

        #endregion       

        public string DomainName { get; set; }
    }
}
