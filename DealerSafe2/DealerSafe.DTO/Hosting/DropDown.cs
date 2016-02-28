using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class DropDown
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
        public bool? Multiple { get; set; }
    }
}
