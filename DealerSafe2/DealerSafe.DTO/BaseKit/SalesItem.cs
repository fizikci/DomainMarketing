
namespace DealerSafe.DTO.BaseKit
{
    public class SalesItem
    {
        public int MemberId { get; set; }
        public int OrderID { get; set; }
        public int OrdersDetail { get; set; }
        public int ProductID { get; set; }
        public int TargetID { get; set; }
        public int ServerID { get; set; }
        public int ProductTypeId { get; set; }
        public int DomainID { get; set; }
        public int ProductQuantity { get; set; }
        public string SunucuEklenti { get; set; }
        public string Email { get; set; }
        public string EMailName { get; set; }
        public string EMailPass { get; set; }
        public string EMailAck { get; set; }
        public string Domain { get; set; }
        public int DomainSize { get; set; }
        public int DomainMaxSize { get; set; }
        //
        public string kayit { get; set; }
        public string tip { get; set; }
        public string bilgi { get; set; }
        //
        public string kayitadi { get; set; }
        public string kayitbilgisi { get; set; }
        //
        public bool IsNew { get; set; }
        //
        public bool Kurulum { get; set; }

        public int Size()
        {
            return DomainMaxSize - DomainSize;
        }

        public SalesItem()
        {
            SunucuEklenti = "-";
            Email = "";
            EMailName = "";
            EMailPass = "";
            EMailAck = "";
            Domain = "";
            kayit = "";
            tip = "";
            bilgi = "";
            Kurulum = false;
        }
    }
}
