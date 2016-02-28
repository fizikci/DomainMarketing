namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Name server model
    /// </summary>
    public class NameServerTo
    {
        public string HostName { get; set; }

        public List<string> Addresses { get; set; }
    }
}
