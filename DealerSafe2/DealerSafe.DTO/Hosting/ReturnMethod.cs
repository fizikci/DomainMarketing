namespace DealerSafe.DTO.Hosting
{
    public class ReturnMethod 
    {
        public string DisplayMessage { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public dynamic Data { get; set; }

        public string Request { get; set; }
        public string Response { get; set; }
        public int QueueId { get; set; }
        public string MethodName { get; set; }
    }
}