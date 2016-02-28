namespace DealerSafe.DTO.Hosting
{
    using System;

    [Serializable]
    public class WaitingMigrationInfo
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedMember { get; set; }
        public int HostingId { get; set; }
        public String ServerIp { get; set; }
        public int ProductType { get; set; }
        public int OperationSystem { get; set; }
        public int Status { get; set; }
    }
}
