namespace Epp.Protocol.Commands
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Object model for "cd" element
    /// </summary>
    internal class CDItem
    {
        /// <summary>
        /// Initializes a new instance of the CDItem class
        /// </summary>
        /// <param name="checkDataElement">"cd" element</param>
        internal CDItem(XElement checkDataElement)
        {
            this.ObjectElement = checkDataElement.Elements().FirstOrDefault();
            if (this.ObjectElement == null)
            {
                throw new ArgumentException("cd element must contain object specific element");
            }

            var avail = this.ObjectElement.Attribute("avail");
            if (avail == null)
            {
                throw new ArgumentException("Object specific elemen must contain avail attribute");
            }

            try
            {
                this.Available = (bool)Convert.ChangeType(avail.Value, typeof(bool));
            }
            catch
            {
                this.Available = ((int)Convert.ChangeType(avail.Value, typeof(int))) != 0;
            }

            var objectNamespace = checkDataElement.Name.Namespace;

            var reasonElement = checkDataElement.Element(objectNamespace.GetName("reason"));
            if (reasonElement != null)
            {
                this.Reason = reasonElement.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the object is available for provisioning
        /// </summary>
        public bool Available
        {
            get;
            set;
        }

        /// <summary>
        /// Gets specific object element in "cd" element
        /// </summary>
        public XElement ObjectElement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets reason text
        /// </summary>
        public string Reason
        {
            get;
            set;
        }
    }
}