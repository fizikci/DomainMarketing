namespace DealerSafe.DTO.Domain
{
    public class ReqUpdateQueueReportTypeAndProcessType
    {
        public int QueueProcessTypeId { get; set; }
        public int QueueReportTypeId { get; set; }
        public int QueueProcessStatus { get; set; }
        public int QueueId { get; set; }
    }
}
