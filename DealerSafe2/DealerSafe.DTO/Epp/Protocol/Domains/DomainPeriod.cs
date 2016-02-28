namespace Epp.Protocol.Domains
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Presents domain registration period in years or months
    /// </summary>
    [Serializable]
    public class DomainPeriod
    {
        /// <summary>
        /// Initializes a new instance of the DomainPeriod class
        /// </summary>
        /// <param name="units">Period units</param>
        /// <param name="period">Period value</param>
        public DomainPeriod(PeriodUnits units, int period)
        {
            this.Units = units;
            this.Period = period;
        }

        /// <summary>
        /// Initializes a new instance of the DomainPeriod class
        /// </summary>
        /// <param name="periodMonths">Period value in months</param>
        /// <remarks>
        /// Default units is month (12..120)
        /// </remarks>
        public DomainPeriod(int periodMonths)
        {
            this.Period = periodMonths;
            this.Units = PeriodUnits.Month;
        }
        /// <summary>
        /// Initializes a new instance of the DomainPeriod class
        /// </summary>
        /// <param name="value">period value (12..120 month or 1..10 years)</param>
        /// <param name="units">period units month or year</param>
        public DomainPeriod(int value, PeriodUnits units)
        {
            this.Period = value;
            this.Units = units;
        }

        public DomainPeriod() : this(PeriodUnits.Year, 1)
        {
        }

        #region PeriodUnits enum

        /// <summary>
        /// Presents registration period units
        /// </summary>
        [Serializable]
        public enum PeriodUnits
        {
            /// <summary>
            /// Period will be presented in years
            /// </summary>
            Year,

            /// <summary>
            /// Period will be presented in months
            /// </summary>
            Month
        }

        #endregion

        /// <summary>
        /// Gets period units
        /// </summary>
        public PeriodUnits Units { get; set; }

        /// <summary>
        /// Gets period value
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Fills period XML element with content
        /// </summary>
        /// <param name="periodElement">Period XML element</param>
        public void Fill(XElement periodElement)
        {
            var unitAttr = new XAttribute("unit", this.Units == PeriodUnits.Month ? "m" : "y");
            periodElement.Add(unitAttr);
            periodElement.SetValue(this.Period);
        }
    }
}