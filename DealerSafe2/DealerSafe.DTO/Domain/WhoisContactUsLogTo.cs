namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class WhoisContactUsLogTo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Creation { get; set; }
    }
}
