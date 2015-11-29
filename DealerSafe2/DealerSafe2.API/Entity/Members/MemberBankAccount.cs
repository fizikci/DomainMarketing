using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public partial class MemberBankAccount : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BrunchNumber { get; set; }
        public string HolderName { get; set; }
        public string HolderIdentity { get; set; }
        public string AccountTitle { get; set; }
        public string AcountNumber { get; set; }
        public string IBAN { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

    }
}