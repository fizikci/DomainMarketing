using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class SSLTypesInfo
    {
        public bool Process { get; set; }
        public List<SSLTypeDetail> SSLTypes { get; set; }

        public class SSLTypeDetail
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int OpensrsId { get; set; }
            public float Price { get; set; }
            public float Price1Year { get; set; }
            public float Price2Year { get; set; }
            public float Price3Year { get; set; }
            public float Price4Year { get; set; }
            public float Price5Year { get; set; }
            public string Detail { get; set; }
            public float Tax { get; set; }
            public int Status { get; set; }
            public int Company { get; set; }
        }
    }
}
