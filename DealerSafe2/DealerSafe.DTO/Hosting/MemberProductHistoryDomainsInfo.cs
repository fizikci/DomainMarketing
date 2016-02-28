using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Hosting
{
    public class MemberProductHistoryDomainsInfo
    {
        public int Id { get; set; }
        public bool BackupChoose { get; set; }
        public int BackupCreate { get; set; }
        public int BackupRestore { get; set; }
        public bool StaffControl { get; set; }
        public int HistoryId { get; set; }
        public int BackupMemberId { get; set; }
        public DateTime BackupDate { get; set; }
        public int HostingId { get; set; }
        public string DomainName { get; set; }
        public string DomainUser { get; set; }
        public string Pass { get; set; }
        public DateTime CompletedDate { get; set; }
        public int RestoreMemberId { get; set; }
    }
}
