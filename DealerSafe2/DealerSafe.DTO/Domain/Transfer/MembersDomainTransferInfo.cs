namespace DealerSafe.DTO.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Adress Details of Domain owner
    /// </summary>
    public class MembersDomainTransferInfo
    {
        [Description("Domain Id")]
        public int DomainId { get; set; }

        [Description("Domain Transfer Status")]
        public DomainTransferStatus Status { get; set; }
    }

    public enum DomainTransferStatus
    {
        IncorrectPassword,
        LockedDomain,
        ApprovedByDomainOwner
    }



}
