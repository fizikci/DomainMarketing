namespace Epp.Protocol.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Shared;

    /// <summary>
    /// Represents adding or removing information for the contact update command
    /// </summary>
    [Serializable]
    public class ContactAddRemType
    {
        /// <summary>
        /// Status values to be associated with or removed from the object
        /// </summary>
        private List<StatusInfo> statuses;

        /// <summary>
        /// Gets status values to be associated with or removed from the object
        /// </summary>
        public List<StatusInfo> Statuses
        {
            get
            {
                return this.statuses;
            }

            set
            {
                this.statuses = (value ?? Enumerable.Empty<StatusInfo>()).ToList();
            }
        }

        /// <summary>
        /// Fill specified XML element with the addRemType information
        /// </summary>
        /// <param name="addRemElement">AddRemElement XML element to fill</param>
        public void Fill(XElement addRemElement)
        {
            foreach (var status in this.Statuses)
            {
                var st = new XElement(SchemaHelper.ContactNs.GetName("status"));
                status.Fill(st);
                addRemElement.Add(st);
            }
        }
    }
}
