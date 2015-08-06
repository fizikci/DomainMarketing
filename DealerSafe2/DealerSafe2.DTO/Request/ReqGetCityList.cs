namespace DealerSafe2.DTO.Request
{
    public class ReqGetCityList : BaseRequest
    {
        public string CountryId { get; set; }
        public string StateId { get; set; }
    }
}
