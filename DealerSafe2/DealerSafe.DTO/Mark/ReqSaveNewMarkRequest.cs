using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveNewMarkRequest
    {
        public string YeniArastirmaTarih { get; set; }
        public string YeniArastirmaMusteriAdi { get; set; }
        public string YeniArastirmaMusteriID { get; set; }
        public string YeniArastirmaMusteriEmail { get; set; }
        public string YeniArastirmaMusteriPhone { get; set; }
        public string YeniArastirmaMusteriMobile { get; set; }
        public string YeniArastirmaSiniflar { get; set; }
        public string YeniArastirmaMarkaAdi { get; set; }
        public string YeniArastirmaAciklama { get; set; }
        public string YeniArastirmaSatisNotu { get; set; }
        public string YeniArastirmaTipi { get; set; }
    }
}
