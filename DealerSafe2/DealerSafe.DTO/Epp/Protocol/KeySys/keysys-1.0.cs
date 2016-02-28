using System.Runtime.Serialization;
using System.Xml.Linq;
using Epp.Protocol;


namespace DealerSafe.DTO.Epp.Protocol.KeySys
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.key-systems.net/epp/keysys-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("resData", Namespace = "http://www.key-systems.net/epp/keysys-1.0", IsNullable = false)]
    public partial class resDataType : GeneratedEppEntity<resDataType>
    {

        private infDataType _infData;

        public resDataType()
        {
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public infDataType infData
        {
            get
            {
                return this._infData;
            }
            set
            {
                this._infData = value;
            }
        }


    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.key-systems.net/epp/keysys-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("infData", Namespace = "http://www.key-systems.net/epp/keysys-1.0", IsNullable = false)]
    public partial class infDataType : GeneratedEppEntity<infDataType>
    {

        private DateTime _renDate;
        private string _renewalmode;
        private string _transferlock;
        private string _transfermode;

        public infDataType()
        {
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public DateTime renDate
        {
            get
            {
                return this._renDate;
            }
            set
            {
                this._renDate = value;
            }
        }

        /// <summary>
        /// DEFAULT, RENEWONCE, AUTORENEW, AUTOEXPIRE, AUTODELETE, EXPIREAUCTION
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string renewalmode
        {
            get
            {
                return this._renewalmode;
            }
            set
            {
                this._renewalmode = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string transferlock
        {
            get
            {
                return this._transferlock;
            }
            set
            {
                this._transferlock = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string transfermode
        {
            get
            {
                return this._transfermode;
            }
            set
            {
                this._transfermode = value;
            }
        }


    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.key-systems.net/epp/keysys-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("update", Namespace = "http://www.key-systems.net/epp/keysys-1.0", IsNullable = false)]
    public partial class updateType : GeneratedEppEntity<updateType>
    {

        private domainType _domain;

        public updateType()
        {
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public domainType domain
        {
            get
            {
                return this._domain;
            }
            set
            {
                this._domain = value;
            }
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.key-systems.net/epp/keysys-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("domain", Namespace = "http://www.key-systems.net/epp/keysys-1.0", IsNullable = false)]
    public partial class domainType : GeneratedEppEntity<domainType>
    {
        private string _renewalmode;

        public domainType()
        {
        }

        /// <summary>
        /// DEFAULT, RENEWONCE, AUTORENEW, AUTOEXPIRE, AUTODELETE, EXPIREAUCTION
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string renewalmode
        {
            get
            {
                return this._renewalmode;
            }
            set
            {
                this._renewalmode = value;
            }
        }

        private string roCompanyNumber;

        /// <summary>
        /// Domaini alan firmanýn vergi numarasý ya da TC kimlik no
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1, ElementName = "ro-company-number")]
        public string RoCompanyNumber
        {
            get
            {
                return this.roCompanyNumber;
            }
            set
            {
                this.roCompanyNumber = value;
            }
        }

        [XmlElementAttribute("es-admin-identificacion", DataType = "token", Order = 65)]
        public string esadminidentificacion { get; set; }

        [XmlElementAttribute("es-admin-legalform", DataType = "token", Order = 66)]
        public string esadminlegalform { get; set; }

        [XmlElementAttribute("es-admin-tipo-identificacion", DataType = "token", Order = 67)]
        public string esadmintipoidentificacion { get; set; }

        [XmlElementAttribute("es-billing-identificacion", DataType = "token", Order = 68)]
        public string esbillingidentificacion { get; set; }

        [XmlElementAttribute("es-billing-legalform", DataType = "token", Order = 69)]
        public string esbillinglegalform { get; set; }

        [XmlElementAttribute("es-billing-tipo-identificacion", DataType = "token", Order = 70)]
        public string esbillingtipoidentificacion { get; set; }

        [XmlElementAttribute("es-owner-identificacion", DataType = "token", Order = 71)]
        public string esowneridentificacion { get; set; }

        [XmlElementAttribute("es-owner-legalform", DataType = "token", Order = 72)]
        public string esownerlegalform { get; set; }

        [XmlElementAttribute("es-owner-tipo-identificacion", DataType = "token", Order = 73)]
        public string esownertipoidentificacion { get; set; }

        [XmlElementAttribute("es-registrant-identificacion", DataType = "token", Order = 74)]
        public string esregistrantidentificacion { get; set; }

        [XmlElementAttribute("es-registrant-tipo-identificacion", DataType = "token", Order = 75)]
        public string esregistranttipoidentificacion { get; set; }

        [XmlElementAttribute("es-tech-identificacion", DataType = "token", Order = 76)]
        public string estechidentificacion { get; set; }

        [XmlElementAttribute("es-tech-legalform", DataType = "token", Order = 77)]
        public string estechlegalform { get; set; }

        [XmlElementAttribute("es-tech-tipo-identificacion", DataType = "token", Order = 78)]
        public string estechtipoidentificacion { get; set; }

        [XmlElementAttribute("eu-accept-trustee-tac", DataType = "token", Order = 79)]
        public string euaccepttrusteetac { get; set; }

        [XmlElementAttribute("eu-registrant-lang", DataType = "token", Order = 80)]
        public string euregistrantlang { get; set; }


        [System.Xml.Serialization.XmlElementAttribute(Order = 187, ElementName = "nu-iis-idno")]
        public string NuIisIdNo { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Order = 188, ElementName = "nu-iis-vatno")]
        public string NuIisVatNo { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.key-systems.net/epp/keysys-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("create", Namespace = "http://www.key-systems.net/epp/keysys-1.0", IsNullable = false)]
    public partial class createType : GeneratedEppEntity<createType>
    {
        private domainType _domain;

        public createType()
        {
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public domainType domain
        {
            get
            {
                return this._domain;
            }
            set
            {
                this._domain = value;
            }
        }
    }
}
