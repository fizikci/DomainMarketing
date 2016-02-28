using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class PhysicalServerInfo
    {               
        public int Id { get; set; }

        public string Description { get; set; }
        public string Cpu { get; set; }
        public string Disk { get; set; }
        public string Ram { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DealerSafe.DTO.Enums.EnmPhysicalServerStatus Status { get; set; }
        public int MemberId { get; set; }
        public int OrderId { get; set; }
        public string Os { get; set; }
        public string Panel { get; set; }
        public string Trafik { get; set; }
        public string Marka { get; set; }
        public string Ip { get; set; }        

        public bool IsExpired {get; set;}        
    }    
}
