namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// Domain Check Model
    /// </summary>
    public class ReqHostCreate
    {
        public string Cns { get; set; }
        public int DomainId { get; set; }
        public string Ip { get; set; }
    }
}
