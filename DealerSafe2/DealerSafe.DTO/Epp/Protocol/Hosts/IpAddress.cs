namespace Epp.Protocol.Hosts
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Holds informating about host IP address
    /// </summary>
    [Serializable]
    public class IpAddress
    {
        /// <summary>
        /// Initializes a new instance of the IpAddress class with specified type and address
        /// </summary>
        /// <param name="type">IP address type</param>
        /// <param name="address">IP address</param>
        public IpAddress(IpAddressType type, string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            this.Type = type;
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the IpAddress class with specified address
        /// </summary>
        /// <param name="address">IP address</param>
        public IpAddress(string address)
            : this(IpAddressType.V4, address)
        {
        }

        public IpAddress()
        {
        }

        #region IpAddressType enum

        /// <summary>
        /// IP adress type
        /// </summary>
        [Serializable]
        public enum IpAddressType
        {
            /// <summary>
            /// IP address version 4
            /// </summary>
            V4,

            /// <summary>
            /// IP address version 6
            /// </summary>
            V6,
        }

        #endregion
        
        /// <summary>
        /// Gets IP address type
        /// </summary>
        public IpAddressType Type { get; set; }

        /// <summary>
        /// Gets IP address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Extracts IP address from XML element
        /// </summary>
        /// <param name="addressElement">XML element containing IP address</param>
        /// <returns>IpAddress object, containing information about IP address</returns>
        public static IpAddress Extract(XElement addressElement)
        {
            XAttribute typeAttr = addressElement.Attribute("ip");
            IpAddressType type = typeAttr == null ? IpAddressType.V4 : typeAttr.Value.ToEnum<IpAddressType>();
            return new IpAddress(type, addressElement.Value);
        }

        /// <summary>
        /// Fill specified address XML element with the IP address
        /// </summary>
        /// <param name="addressElement">Address XML element to fill</param>
        public void Fill(XElement addressElement)
        {
            addressElement.SetValue(this.Address);
            addressElement.Add(new XAttribute("ip", this.Type.ToString().ToLowerInvariant()));
        }
    }
}