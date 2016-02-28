using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResNewTldAllQuery
    {
        public string Tld { get; set; }

        public int DomainTypesId { get; set; }

        public double Price { get; set; }

        public DtoStatus Statues { get; set; }

    }

    public enum DtoStatus
    {
        Pasif = 0,
        GeneralAvalible = 1,
        Specical = 2,
        Coming = 3
    }

}
