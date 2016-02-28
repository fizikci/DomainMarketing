namespace Epp.Protocol.Domains
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hosts;

    /// <summary>
    /// Holds information about name service for domain info and create commands
    /// </summary>
    [Serializable]
    public class NameServerInfo
    {
        /// <summary>
        /// Initializes a new instance of the NameServerInfo class
        /// </summary>
        /// <param name="hostName">Name server host name</param>
        /// <param name="addresses">Name server address list</param>
        public NameServerInfo(string hostName, IEnumerable<IpAddress> addresses)
        {
            this.HostName = hostName;
            this.Addresses = (addresses ?? Enumerable.Empty<IpAddress>()).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the NameServerInfo class
        /// </summary>
        /// <param name="hostName">Name server host name</param>
        public NameServerInfo(string hostName)
            : this(hostName, null)
        {
        }

        public NameServerInfo() : this("HOSTNAME")
        {
        }

        /// <summary>
        /// Gets name server host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets name server address list
        /// </summary>
        public List<IpAddress> Addresses { get; set; }
    }
}