using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class MemberHostingsDdlInfo
    {
        public string Name { get; set; }
        public string OperatingSystem { get; set; }
        public int Id { get; set; }

        public string FullName
        {
            get { return Id + "-" + Name + " (" + (OperatingSystem == "1" ? "windows" : "linux") + ")"; }
        }
    }
}
