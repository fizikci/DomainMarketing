namespace DealerSafe.DTO.Domain
{
    public class MemberDnsListTo
    {
        public int Id { get; set; }
        public decimal MemberID { get; set; }
        public string DNS1Name { get; set; }
        public string DNS1IP { get; set; }
        public string DNS2Name { get; set; }
        public string DNS2IP { get; set; }
        public string DNS3Name { get; set; }
        public string DNS3IP { get; set; }
        public string DNS4Name { get; set; }
        public string DNS4IP { get; set; }
        public string DNS5Name { get; set; }
        public string DNS5IP { get; set; }
        public int DefaultStatus { get; set; }
        public int Status { get; set; }
        public int IsFirstDNS { get; set; }
    }
}
