using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain
{
    public class DomainTransfer
    {
        public decimal DomainId { get; set; }
        public string DomainName { get; set; }
        public string DomainProcess { get; set; }
    }

    public class Transfer_Control
    {
        public int MemberId { get; set; }
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public EnmInTransferDomainStatus Status { get; set; }
        public string Password { get; set; }
        public string DirectiOrderID { get; set; }
        public string MemberEmail { get; set; }
        public string Surname { get; set; }
    }

    public class MemberDnsList
    {
        public decimal Id { get; set; }
        public decimal MemberId { get; set; }
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public string Password { get; set; }
        public EnmInTransferDomainStatus Status { get; set; }
        public string EndDate { get; set; }
    }

    public enum EnmDomainStatus
    {
        /// <remarks/>
        STATUS_CLIENT_HOLD,

        /// <remarks/>
        STATUS_CLIENT_DELETE_PROHIBITED,

        /// <remarks/>
        STATUS_CLIENT_RENEW_PROHIBITED,

        /// <remarks/>
        STATUS_CLIENT_TRANSFER_PROHIBITED,

        /// <remarks/>
        STATUS_CLIENT_UPDATE_PROHIBITED,
    }


}
