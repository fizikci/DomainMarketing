using System;

namespace DealerSafe.DTO.Support
{
    [Serializable]
    public class SupportStaff
    {
        public int Id = 0;
        public string FullName = "";
        public string Email = "";
        public bool Status = false;
    }
}