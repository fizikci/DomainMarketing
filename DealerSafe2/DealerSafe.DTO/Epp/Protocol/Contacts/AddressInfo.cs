namespace Epp.Protocol.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents an address information associated with the contact
    /// </summary>
    [Serializable]
    public class AddressInfo
    {
        /// <summary>
        /// Contact's street address
        /// </summary>
        private List<string> streets;

        /// <summary>
        /// Initializes a new instance of the AddressInfo class
        /// </summary>
        /// <param name="city">Contact's city</param>
        /// <param name="countryCode">Contact's country code</param>
        public AddressInfo(string city, string countryCode)
        {
            this.City = city;
            this.CountryCode = countryCode;
        }

        public AddressInfo() : this("CITY", "TR")
        {
            
        }

        /// <summary>
        /// Gets or sets the contact's street address
        /// </summary>
        public List<string> Streets
        {
            get
            {
                return this.streets;
            }

            set
            {
                this.streets = (value ?? Enumerable.Empty<string>()).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the contact's city 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the contact's state or province
        /// </summary>
        public string SP { get; set; }

        /// <summary>
        /// Gets or sets the contact's postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the contact's country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Extracts address information from XML element
        /// </summary>
        /// <param name="addressElement">XML element containing address information</param>
        /// <returns>An object of AddressInfo class, containing address information</returns>
        public static AddressInfo Extract(XElement addressElement)
        {
            var city = addressElement.Element(SchemaHelper.ContactNs.GetName("city")).Value;
            var countryCode = addressElement.Element(SchemaHelper.ContactNs.GetName("cc")).Value;
            var addressInfo = new AddressInfo(city, countryCode);
            addressInfo.Streets = addressElement
                .Elements()
                .Where(elem => elem.Name.LocalName == "street")
                .Select(street => street.Value)
                .ToList();

            var stateElem = addressElement.Element(SchemaHelper.ContactNs.GetName("sp"));
            addressInfo.SP = stateElem == null ? null : stateElem.Value;

            var postalCodeElem = addressElement.Element(SchemaHelper.ContactNs.GetName("pc"));
            addressInfo.PostalCode = postalCodeElem == null ? null : postalCodeElem.Value;

            return addressInfo;
        }

        /// <summary>
        /// Fill specified address XML element with the address information
        /// </summary>
        /// <param name="addressElement">Address XML element to fill</param>
        public void Fill(XElement addressElement)
        {
            if (this.Streets != null)
            {
                foreach (var street in this.Streets)
                {
                    addressElement.Add(new XElement(SchemaHelper.ContactNs.GetName("street"), street));
                }
            }

            addressElement.Add(new XElement(SchemaHelper.ContactNs.GetName("city"), this.City));

            if (this.SP != null)
            {
                addressElement.Add(new XElement(SchemaHelper.ContactNs.GetName("sp"), this.SP));
            }

            if (this.PostalCode != null)
            {
                addressElement.Add(new XElement(SchemaHelper.ContactNs.GetName("pc"), this.PostalCode));
            }

            addressElement.Add(new XElement(SchemaHelper.ContactNs.GetName("cc"), this.CountryCode));
        }
    }
}
