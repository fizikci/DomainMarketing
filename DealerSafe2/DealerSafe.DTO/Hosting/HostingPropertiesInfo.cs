using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class HostingPropertiesInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpertaingSystem { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool PageLoad { get; set; }
    }
}
