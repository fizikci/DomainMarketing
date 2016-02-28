namespace Epp.Protocol.Hosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Represents Add\Remove type for hosts
    /// </summary>
    [Serializable]
    public class HostAddRemType
    {
        /// <summary>
        /// IP addresses to be associated with or removed from the host object
        /// </summary>
        private List<IpAddress> addr;

        /// <summary>
        /// Status values to be associated with or removed from the object
        /// </summary>
        private List<StatusInfo> statuses;

        /// <summary>
        /// Initializes a new instance of the HostAddRemType class
        /// </summary>
        /// <param name="addresses">List of added or removed IP addresses</param>
        public HostAddRemType(List<IpAddress> addresses)
        {
            if (addresses == null)
            {
                throw new ArgumentNullException("addresses");
            }

            this.Addr = addresses;
        }

        /// <summary>
        /// Initializes a new instance of the HostAddRemType class
        /// </summary>
        /// <param name="statuses">List of added or removed statuses</param>
        public HostAddRemType(List<StatusInfo> statuses)
        {
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses");
            }

            this.Statuses = statuses;
        }

        public HostAddRemType()
        {
        }

        /// <summary>
        /// Gets or sets elements that contain IP addresses to be associated with or removed from the host object
        /// </summary>
        public List<IpAddress> Addr
        {
            get
            {
                return this.addr;
            }

            set
            {
                this.addr = (value == null) ? new List<IpAddress>() : value.ToList();
            }
        }

        /// <summary>
        /// Gets or sets status values to be associated with or removed from the object
        /// </summary>
        public List<StatusInfo> Statuses
        {
            get
            {
                return this.statuses;
            }

            set
            {
                this.statuses = (value == null) ? new List<StatusInfo>() : value.ToList();
            }
        }

        /// <summary>
        /// Extracts AddRemType object from XML element
        /// </summary>
        /// <param name="addRemElement">AddRemType XML element</param>
        /// <returns>AddRemType object</returns>
        public static HostAddRemType Extract(XElement addRemElement)
        {
            var addresses = addRemElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "addr")
                .Select(addr => IpAddress.Extract(addr));
            var statuses = addRemElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "status")
                .Select(status => StatusInfo.Extract(status));
            HostAddRemType addRemType;
            if (addresses != null)
            {
                addRemType = new HostAddRemType(addresses.ToList());
                if (statuses != null)
                {
                    addRemType.Statuses = statuses.ToList();
                }
            }
            else
            {
                addRemType = new HostAddRemType(statuses.ToList());
            }

            return addRemType;
        }

        /// <summary>
        /// Fill specified XML element with the status info
        /// </summary>
        /// <param name="addRemElement">AddRemType XML element</param>
        public void Fill(XElement addRemElement)
        {
            if (this.Addr != null)
            {
                foreach (var address in this.Addr)
                {
                    var addrElem = new XElement(SchemaHelper.HostNs.GetName("addr"));
                    address.Fill(addrElem);
                    addRemElement.Add(addrElem);
                }
            }

            if (this.Statuses != null)
            {
                foreach (var status in this.Statuses)
                {
                    var statusElem = new XElement(SchemaHelper.HostNs.GetName("status"));
                    status.Fill(statusElem);
                    addRemElement.Add(statusElem);
                }
            }
        }
    }
}
