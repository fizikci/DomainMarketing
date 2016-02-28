namespace Epp.Protocol
{
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using DealerSafe.DTO.Properties;
    using Reflection;

    /// <summary>
    /// Presents helper members to manipulate with XML schemas
    /// </summary>
    public static class SchemaHelper
    {
        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:eppcom-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace EppComNs = XNamespace.Get("urn:ietf:params:xml:ns:eppcom-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:epp-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace EppNs = XNamespace.Get("urn:ietf:params:xml:ns:epp-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:host-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace HostNs = XNamespace.Get("urn:ietf:params:xml:ns:host-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:domain-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace DomainNs = XNamespace.Get("urn:ietf:params:xml:ns:domain-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:contact-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace ContactNs = XNamespace.Get("urn:ietf:params:xml:ns:contact-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:secDNS-1.0" XML namespace
        /// </summary>
        public static readonly XNamespace SecDns10Ns = XNamespace.Get("urn:ietf:params:xml:ns:secDNS-1.0");

        /// <summary>
        /// Instance of "urn:ietf:params:xml:ns:secDNS-1.1" XML namespace
        /// </summary>
        public static readonly XNamespace SecDnsNs = XNamespace.Get("urn:ietf:params:xml:ns:secDNS-1.1");

        /// <summary>
        /// Instance of "http://www.w3.org/2001/XMLSchema" XML namespace
        /// </summary>
        public static readonly XNamespace XmlSchemaNs = XNamespace.Get("http://www.w3.org/2001/XMLSchema");

        /// <summary>
        /// Instance of "http://www.w3.org/2001/XMLSchema-instance" XML namespace
        /// </summary>
        public static readonly XNamespace XsiNs = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

        public static readonly XNamespace FinanceNs = XNamespace.Get("http://www.unitedtld.com/epp/finance-1.0");
        public static readonly XNamespace LaunchNs = XNamespace.Get("urn:ietf:params:xml:ns:launch-1.0");
        public static readonly XNamespace BalanceNs = XNamespace.Get("http://www.verisign.com/epp/balance-1.0");
        public static readonly XNamespace PremiumDomainNs = XNamespace.Get("http://www.verisign.com/epp/premiumdomain-1.0");
        public static readonly XNamespace RgpNs = XNamespace.Get("urn:ietf:params:xml:ns:rgp-1.0");
        public static readonly XNamespace NameStoreNs = XNamespace.Get("http://www.verisign-grs.com/epp/namestoreExt-1.1");
        public static readonly XNamespace KeySysNs = XNamespace.Get("http://www.key-systems.net/epp/keysys-1.0");
        public static readonly XNamespace Fee07Ns = XNamespace.Get("urn:ietf:params:xml:ns:fee-0.7");
        public static readonly XNamespace Fee06Ns = XNamespace.Get("urn:ietf:params:xml:ns:fee-0.6");
        public static readonly XNamespace Fee05Ns = XNamespace.Get("urn:ietf:params:xml:ns:fee-0.5");
        public static readonly XNamespace PriceNs = XNamespace.Get("urn:afilias:params:xml:ns:price-1.0");
        public static readonly XNamespace ChargeNs = XNamespace.Get("http://www.unitedtld.com/epp/charge-1.0");


        /// <summary>
        /// Full EPP schema set
        /// </summary>
        private static readonly XmlSchemaSet schemaSet;

        /// <summary>
        /// Initializes static members of the SchemaHelper class
        /// </summary>
        static SchemaHelper()
        {
            schemaSet = new XmlSchemaSet();
            
            foreach (var schema in XmlSchemaDiscoverer.GetSchemas())
            {
                schemaSet.Add(XmlSchema.Read(new StringReader(schema), null));
            }

            schemaSet.Compile();
        }

        /// <summary>
        /// Gets full EPP schema set
        /// </summary>
        public static XmlSchemaSet SchemaSet
        {
            get { return schemaSet; }
        }

        /// <summary>
        /// Gets hello message text
        /// </summary>
        public static string HelloMessage
        {
            get { return Resources.HelloMessage; }
        }

        /// <summary>
        /// Creates base document for all EPP messages
        /// </summary>
        /// <returns>Base XML document for all EPP messages</returns>
        public static XDocument CreateEppBaseDocument()
        {
            return XDocument.Parse(Resources.EppMessageBase);
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="schema location" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        /// <param name="schemaLocation">Schema location text</param>
        internal static void AddSchemaLocation(this XElement element, string schemaLocation)
        {
            element.Add(new XAttribute(MessageBase.XsiNs.GetName("schemaLocation"), schemaLocation));
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:contact-1.0 contact-1.0.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddContactSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.ContactSchemaLocation);
            element.Add(new XAttribute(XNamespace.Xmlns + "contact", SchemaHelper.ContactNs));
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:domain-1.0 domain-1.0.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddDomainSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.DomainSchemaLocation);
            element.Add(new XAttribute(XNamespace.Xmlns + "domain", SchemaHelper.DomainNs));
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:host-1.0 host-1.0.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddHostSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.HostSchemaLocation);
            element.Add(new XAttribute(XNamespace.Xmlns + "host", SchemaHelper.HostNs));
        }

        /*
        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:secDNS-1.0 secDNS-1.0.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddSecDns10SchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.SecDns10SchemaLocation);
        }
        */

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:secDNS-1.1 secDNS-1.1.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddSecDnsSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.SecDnsSchemaLocation);
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:secDNS-1.1 secDNS-1.1.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddFinanceSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.FinanceSchemaLocation);
        }

        /// <summary>
        /// Adds an xsi:schemaLocation="urn:ietf:params:xml:ns:secDNS-1.1 secDNS-1.1.xsd" attribute
        /// </summary>
        /// <param name="element">Target element</param>
        internal static void AddLaunchSchemaLocation(this XElement element)
        {
            element.AddSchemaLocation(Resources.LaunchSchemaLocation);
        }

    }
}