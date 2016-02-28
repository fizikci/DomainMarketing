namespace Epp.Protocol.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents element that allows a client to
    /// identify elements that require exceptional server operator
    /// handling to allow or restrict disclosure to third parties
    /// </summary>
    [Serializable]
    public class Disclose
    {
        /// <summary>
        /// Data elements that allow a client to identify elements that require
        /// exceptional server operator handling to allow or restrict disclosure
        /// to third parties
        /// </summary>
        private List<string> disclosingFields;

        /// <summary>
        /// Initializes a new instance of the Disclose class
        /// </summary>
        /// <param name="flag">The "flag" attribute contains an XML Schema boolean value</param>
        public Disclose(bool flag)
        {
            this.Flag = flag;
        }


        public Disclose()
        {
        }

        /// <summary>
        /// Gets a value indicating whether allow disclosure of the specified elements as an exception to the
        /// stated data collection policy
        /// </summary>
        public bool Flag { get; set; }

        /// <summary>
        /// Gets or sets data elements that allow a client to identify elements that require
        /// exceptional server operator handling to allow or restrict disclosure
        /// to third parties
        /// </summary>
        public List<string> DisclosingFields
        {
            get
            {
                return this.disclosingFields;
            }

            set
            {
                this.disclosingFields = (value ?? Enumerable.Empty<string>()).ToList();
            }
        }

        /// <summary>
        /// Extracts disclose object from XML element
        /// </summary>
        /// <param name="discloseElement">XML element containing disclose element</param>
        /// <returns>An object of Disclose class</returns>
        public static Disclose Extract(XElement discloseElement)
        {
            var disclose = new Disclose(Convert.ToBoolean(discloseElement.Attribute("flag").Value));
            if (discloseElement.Elements() != null)
            {
                var elements = new List<string>();
                foreach (var element in discloseElement.Elements())
                {
                    elements.Add(element.Name.LocalName);
                }

                disclose.DisclosingFields = elements;
            }

            return disclose;
        }

        /// <summary>
        /// Fill specified disclose XML element with the disclose element
        /// </summary>
        /// <param name="discloseElement">Disclose XML element to fill</param>
        public void Fill(XElement discloseElement)
        {
            discloseElement.Add(new XAttribute("flag", this.Flag));
            if (this.DisclosingFields != null)
            {
                foreach (var field in this.DisclosingFields)
                {
                    discloseElement.Add(new XElement(SchemaHelper.ContactNs.GetName(field)));
                }
            }
        }
    }
}
