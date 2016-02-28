using DealerSafe.DTO.Orders;

namespace DealerSafe.DTO.MobileBridge
{
   public class ReqAddOrder
    {
       public int MemberId { get; set; }
       public string Ip { get; set; }
       public double TotalPrice { get; set; }
       public string ProductName { get; set; }
       public string RegistryCompany { get; set; }
       public int ProductId { get; set; }
       public string Extention { get; set; }
    }
}
