namespace Epp.Protocol.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the postal address information
    /// </summary>
    [Serializable]
    public class PostalInfo
    {
        /// <summary>
        /// Initializes a new instance of the PostalInfo class
        /// </summary>
        /// <param name="name">Name of the individual or role represented by the contact</param>
        /// <param name="type">"Type" attribute value</param>
        /// <param name="address">Element that contains address information associated with the contact</param>
        public PostalInfo(string name, PostalType type, AddressInfo address)
        {
            this.Name = name;
            this.Type = type;
            this.Address = address;
        }

        public PostalInfo()
        {
        }

        #region PostalType enum

        /// <summary>
        /// Postal type
        /// </summary>
        [Serializable]
        public enum PostalType
        {
            /// <summary>
            /// Internationalized form
            /// </summary>
            Int,

            /// <summary>
            /// Localized form
            /// </summary>
            Loc,
        }

        #endregion

        /// <summary>
        /// Gets or sets the name of the individual or role represented by the contact
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the attribute type value
        /// </summary>
        public PostalType Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the organization with which the contact is affiliated 
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Gets or sets address information associated with the contact
        /// </summary>
        public AddressInfo Address { get; set; }

        /// <summary>
        /// Extracts postal information from XML element
        /// </summary>
        /// <param name="postalElement">XML element containing postal information</param>
        /// <returns>An object of PostalInfo class, containing postal information</returns>
        public static PostalInfo Extract(XElement postalElement)
        {
            var name = postalElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "name")
                .FirstOrDefault()
                .Value;
            var typeAttribute = postalElement.Attribute("type");
            var postalType = typeAttribute == null ? PostalType.Int : typeAttribute.Value.ToEnum<PostalType>();
            var address = postalElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "addr")
                .Select(addr => AddressInfo.Extract(addr))
                .FirstOrDefault();
            var postalInfo = new PostalInfo(name, postalType, address);
            var orgElem = postalElement.Element(SchemaHelper.ContactNs.GetName("org"));
            postalInfo.Organization = orgElem == null ? null : orgElem.Value;
            return postalInfo;
        }

        /// <summary>
        /// Fill specified postal XML element with the postal information
        /// </summary>
        /// <param name="postalElement">Postal XML element to fill</param>
        public void Fill(XElement postalElement)
        {
            postalElement.Add(new XElement(SchemaHelper.ContactNs.GetName("name"), this.Name));
            if (this.Organization != null)
            {
                postalElement.Add(new XElement(SchemaHelper.ContactNs.GetName("org")) { Value = this.Organization });
            }

            postalElement.Add(new XAttribute("type", this.Type.ToString().ToLowerInvariant()));
            var addressElement = new XElement(SchemaHelper.ContactNs.GetName("addr"));
            this.Address.Fill(addressElement);
            postalElement.Add(addressElement);
        }
    }
}
