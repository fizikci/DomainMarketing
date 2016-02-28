namespace Epp.Protocol.Contacts
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a voice telephone number
    /// </summary>
    [Serializable]
    public class VoiceInfo
    {
        /// <summary>
        /// Initializes a new instance of the VoiceInfo class
        /// </summary>
        /// <param name="voice">Voice telephone number</param>
        public VoiceInfo(string voice)
        {
            this.Voice = voice;
        }

        public VoiceInfo()
        {
        }

        /// <summary>
        /// Gets or sets the voice telephone number
        /// </summary>
        public string Voice { get; set; }

        /// <summary>
        /// Gets or sets the attribute "x" value
        /// </summary>
        public string X { get; set; }

        /// <summary>
        /// Extracts VoiceInfo object from XML element
        /// </summary>
        /// <param name="voiceElement">XML element containing voice telephone number</param>
        /// <returns>An object of VoiceInfo class, containing voice telephone number</returns>
        public static VoiceInfo Extract(XElement voiceElement)
        {
            var voiceInfo = new VoiceInfo(voiceElement.Value);
            XAttribute typeAttr = voiceElement.Attribute("x");
            if (typeAttr != null)
            {
                voiceInfo.X = typeAttr.Value;
            }

            return voiceInfo;
        }

        /// <summary>
        /// Fill specified postal XML element with the voice telephone number
        /// </summary>
        /// <param name="voiceElement">Voice XML element to fill</param>
        public void Fill(XElement voiceElement)
        {
            if (this.X != null)
            {
                voiceElement.Add(new XAttribute("x", this.X.ToLowerInvariant()));
            }

            voiceElement.SetValue(this.Voice);
        }
    }
}
