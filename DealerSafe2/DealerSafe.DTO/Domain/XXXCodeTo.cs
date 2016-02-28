using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class XXXCodeTo
    {
        [Description("Primary Key of XXX Code")]
        public int Id { get; set; }

        [Description("XXX Code")]
        public string Code { get; set; }

        [Description("Associate domain's primary key")]
        public int DomainId { get; set; }
    }
}
