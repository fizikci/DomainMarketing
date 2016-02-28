namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Host Info Transfer object
    /// </summary>
    public class HostInfoTo
    {
        public string Name { get; set; }
        public string Roid { get; set; }
        public List<string> Adresses { get; set; }
        public string ClientId { get; set; }
        public string CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? TransferDate { get; set; }
    }
}
