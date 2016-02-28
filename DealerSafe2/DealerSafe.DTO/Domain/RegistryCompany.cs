using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class RegistryCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string AdapterName { get; set; }
    }
}
