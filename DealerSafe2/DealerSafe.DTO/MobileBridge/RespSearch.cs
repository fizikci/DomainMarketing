using System.Collections.Generic;


namespace DealerSafe.DTO.MobileBridge
{
    public class RespSearch
    {
        public string Error { get; set; }
        public List<DomainQueryList> DomainList { get; set; }
    }

    public class DomainQueryList
    {
        public DomainQueryList()
        {
            Availability = false;
        }

        public string Domain { get; set; }
        public bool Availability { get;set;}
        public decimal PriceDefault { get; set; }
        public decimal PriceCurrent { get; set; }
        public int Company { get; set; }
        public int ExtentionId { get; set; }
        public string Extention { get; set; }   
    }

}
