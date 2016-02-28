namespace Epp.Protocol.Domains
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Hosts;

    /// <summary>
    /// Name server list for domain info and create commands
    /// </summary>
    [Serializable]
    public class NameServerList : List<NameServerInfo>
    {
        /// <summary>
        /// Initializes a new instance of the NameServerList class
        /// </summary>
        public NameServerList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NameServerList class
        /// </summary>
        /// <param name="nameServers">Sequence of name servers of domain</param>
        public NameServerList(IEnumerable<NameServerInfo> nameServers)
        {
            if (nameServers == null)
            {
                throw new ArgumentNullException("nameServers");
            }

            this.AddRange(nameServers);
        }

        /// <summary>
        /// Extracts name server list from protocol "ns" XML element
        /// </summary>
        /// <param name="nameServersElement">Protocol "ns" XML element</param>
        /// <returns>Name server list</returns>
        public static NameServerList Extract(XElement nameServersElement)
        {
            List<NameServerInfo> nameServers;
            if (nameServersElement.Elements().Any(elem => elem.Name.LocalName == "hostObj"))
            {
                nameServers = nameServersElement
                    .Elements()
                    .Select(elem => new NameServerInfo(elem.Value))
                    .ToList();
            }
            else
            {
                nameServers = nameServersElement
                    .Elements()
                    .Select(elem =>
                    {
                        var hostName = elem.Element(SchemaHelper.DomainNs.GetName("hostName")).Value;
                        var hostAddrs = elem
                            .Elements(SchemaHelper.DomainNs.GetName("hostAddr"))
                            .Select(addrElem => IpAddress.Extract(addrElem));
                        return new NameServerInfo(hostName, hostAddrs);
                    })
                    .ToList();
            }

            return new NameServerList(nameServers);
        }

        /// <summary>
        /// Adds name server to list
        /// </summary>
        /// <param name="nameServer">Name server to add</param>
        public void Add(NameServerInfo nameServer)
        {
            if (nameServer == null)
            {
                throw new ArgumentNullException("nameServer");
            }

            base.Add(nameServer);
        }

        /// <summary>
        /// Fills specified "ns" XML element with the name servers content
        /// </summary>
        /// <param name="nameServersElement">"ns" XML element</param>
        public void Fill(XElement nameServersElement)
        {
            if (this.Any(nameServer => nameServer.Addresses.Any()))
            {
                var hostAttrElems = this
                    .Select(nameServer =>
                            {
                                var hostNameElem = new XElement(SchemaHelper.DomainNs.GetName("hostName"), nameServer.HostName);
                                var hostAddrElems = nameServer
                                    .Addresses
                                    .Select(hostAddr =>
                                            {
                                                var hostAddrElem =
                                                    new XElement(SchemaHelper.DomainNs.GetName("hostAddr"));
                                                hostAddr.Fill(hostAddrElem);
                                                return hostAddrElem;
                                            });

                                var hostAttrElem = new XElement(SchemaHelper.DomainNs.GetName("hostAttr"), hostNameElem);
                                hostAttrElem.Add(hostAddrElems);
                                return hostAttrElem;
                            });
                nameServersElement.Add(hostAttrElems);
            }
            else
            {
                var hostObjElems = this
                    .Select(nameServer => new XElement(SchemaHelper.DomainNs.GetName("hostObj"), nameServer.HostName));
                nameServersElement.Add(hostObjElems);
            }
        }

        /// <summary>
        /// Fills specified "ns" XML element with the name servers content.
        /// </summary>
        /// <param name="ns">The given nameserver</param>
        /// <param name="nameServersElement">"ns" XML element</param>
        public void Fill(XNamespace ns, XElement nameServersElement)
        {
            if (this.Any(nameServer => nameServer.Addresses.Any()))
            {
                var hostAttrElems = this
                    .Select(nameServer =>
                    {
                        var hostNameElem = new XElement(SchemaHelper.DomainNs.GetName("hostName"), nameServer.HostName);
                        var hostAddrElems = nameServer
                            .Addresses
                            .Select(hostAddr =>
                            {
                                var hostAddrElem =
                                    new XElement(SchemaHelper.DomainNs.GetName("hostAddr"));
                                hostAddr.Fill(hostAddrElem);
                                return hostAddrElem;
                            });

                        var hostAttrElem = new XElement(SchemaHelper.DomainNs.GetName("hostAttr"), hostNameElem);
                        hostAttrElem.Add(hostAddrElems);
                        return hostAttrElem;
                    });
                nameServersElement.Add(hostAttrElems);
            }
            else
            {
                var hostObjElems = this
                    .Select(nameServer => new XElement(ns + "hostObj", nameServer.HostName));
                nameServersElement.Add(hostObjElems);
            }
        }
    }
}