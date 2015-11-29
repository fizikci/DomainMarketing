using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Members
{
    public class ResellerType : NamedEntity
    {
        public int SetupRegisterFee {get; set;}
        public int PrePaidCreditAmount {get; set;}
        public int ValidityInDays {get; set;}
        public int MinAdditionalCreditAmount {get; set;}
        public int AdditionalDays0StartFee {get; set;}
        public int AdditionalDays0EndFee {get; set;}
        public int AdditionalDays30StartFee {get; set;}
        public int AdditionalDays30EndFee {get; set;}
        public int AdditionalDays90StartFee {get; set;}
        public int AdditionalDays90EndFee {get; set;}
        public ListInPartnerNetwork ListInPartnerNetwork { get; set; }
        public SupportGroup SupportGroup { get; set; }
        public int RebateRate {get; set;}
        public bool CashRefund {get; set;}

        public bool CanJoinMdf { get; set; }

    }

}
