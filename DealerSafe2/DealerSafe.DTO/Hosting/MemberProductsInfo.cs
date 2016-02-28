namespace DealerSafe.DTO.Hosting
{
    using System;
    [Serializable]
    public class MemberProductsInfo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderDetailId { get; set; }
        public string Description { get; set; }
        public int CustomizeProduct_Id { get; set; }
        public float PriceTotal { get; set; }
        public string PriceTotalUnit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime ProductStartDate { get; set; }
        public DateTime ProductEndDate { get; set; }
        public string ExtraDescription { get; set; }
        public int UnitEnmVariable { get; set; }
        public decimal MemberID { get; set; }
        public int Activity { get; set; }
        public string OperatingSystem { get; set; }
        public string PanelIP { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int PanelType { get; set; }
        public string HostingType { get; set; }
        public int CmpEkoStandart { get; set; }
        public string ServerIP { get; set; }
    }
}
