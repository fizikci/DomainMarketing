using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ServerTypeInfo
    {
        public bool Process { get; set; }
        public List<ServerTypeDetail> ServerTypesList { get; set; }

        public class ServerTypeDetail
        {
            public int Id { get; set; }
            public int ServerType { get; set; }
            public string ProductName { get; set; }
            public int OperatingSystem { get; set; }
            public double UnitPrice { get; set; }
            public double UnitAmount { get; set; }
            public int MinSelAmount { get; set; }
            public int MaxSelAmount { get; set; }
            public double Tax { get; set; }
            public string Detail { get; set; }
            public bool Status { get; set; }
            public int Group { get; set; }
            public string Ozet { get; set; }
            public int IsSetupFree { get; set; }
            public double YearUnitPrice { get; set; }
            public bool IsPluging { get; set; }
            public string CPU { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public int BandWidth { get; set; }
            public int ControlPanel { get; set; }
            public int DomainRemains { get; set; }
            public int IPAddress { get; set; }
            public int SQL { get; set; }
            public int Ethernet { get; set; }
            public int PluginSupportSystem { get; set; }
            public int PluginSupportServerType { get; set; }
        }
    }
}
