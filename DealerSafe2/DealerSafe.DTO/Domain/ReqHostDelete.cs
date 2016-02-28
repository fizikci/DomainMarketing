namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Domain Check Model
    /// </summary>
    public class ReqHostDelete
    {
        public int DomainId { get; set; }
        public int NameServerId { get; set; }
    }
}
