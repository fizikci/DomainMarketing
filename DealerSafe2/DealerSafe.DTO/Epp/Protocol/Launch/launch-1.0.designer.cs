using System.Runtime.Serialization;
using System.Xml.Linq;
using Epp.Protocol;

namespace DealerSafe.DTO.Epp.Protocol.Launch
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("check", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class checkType : GeneratedEppEntity<checkType>
    {

        private phaseType phaseField;

        private checkFormType typeField;

        public checkType()
        {
            //this.phaseField = new phaseType();
            this.typeField = checkFormType.claims;
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(checkFormType.claims)]
        public checkFormType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class phaseType : GeneratedEppEntity<phaseType>
    {

        private string nameField;

        private phaseTypeValue valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        [XmlIgnore()]
        public phaseTypeValue Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string TextContent
        {
            get { return Value.ToString(); }
            set { }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    public enum phaseTypeValue
    {
        [XmlEnum(Name = "sunrise")]
        sunrise,

        [XmlEnum(Name = "landrush")]
        landrush,

        [XmlEnum(Name = "claims")]
        claims,

        [XmlEnum(Name = "open")]
        open,

        [XmlEnum(Name = "custom")]
        custom,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    public enum checkFormType
    {

        /// <remarks/>
        claims,

        /// <remarks/>
        avail,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("info", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class infoType : GeneratedEppEntity<infoType>
    {

        private phaseType phaseField;

        private string applicationIDField;

        private bool includeMarkField;

        public infoType()
        {
            //this.phaseField = new phaseType();
            this.includeMarkField = false;
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string applicationID
        {
            get
            {
                return this.applicationIDField;
            }
            set
            {
                this.applicationIDField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool includeMark
        {
            get
            {
                return this.includeMarkField;
            }
            set
            {
                this.includeMarkField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("create", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class createType : GeneratedEppEntity<createType>
    {

        private phaseType phaseField;

        private List<object> itemsField;

        private createNoticeType noticeField;

        private objectType typeField;

        private bool typeFieldSpecified;

        /// <summary>
        /// createType class constructor
        /// </summary>
        public createType()
        {
            //this.noticeField = new createNoticeType();
            //this.itemsField = new List<object>();
            //this.phaseField = new phaseType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("codeMark", typeof(codeMarkType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("abstractSignedMark", typeof(abstractSignedMarkType), Namespace = "urn:ietf:params:xml:ns:signedMark-1.0", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("encodedSignedMark", typeof(encodedSignedMarkType), Namespace = "urn:ietf:params:xml:ns:signedMark-1.0", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("signedMark", typeof(signedMarkType), Namespace = "urn:ietf:params:xml:ns:signedMark-1.0", Order = 1)]
        [XmlArrayItem(Type = typeof(codeMarkType))]
        [XmlArrayItem(Type = typeof(abstractSignedMarkType))]
        [XmlArrayItem(Type = typeof(encodedSignedMarkType))]
        [XmlArrayItem(Type = typeof(signedMarkType))]
        [XmlIgnore]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public createNoticeType notice
        {
            get
            {
                return this.noticeField;
            }
            set
            {
                this.noticeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public objectType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class codeMarkType : GeneratedEppEntity<codeMarkType>
    {

        private codeType codeField;

        private markType itemField;

        /// <summary>
        /// codeMarkType class constructor
        /// </summary>
        public codeMarkType()
        {
            //this.itemField = new markType();
            //this.codeField = new codeType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public codeType code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("mark", Namespace = "urn:ietf:params:xml:ns:mark-1.0", Order = 1)]
        public markType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class codeType : GeneratedEppEntity<codeType>
    {

        private string validatorIDField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string validatorID
        {
            get
            {
                return this.validatorIDField;
            }
            set
            {
                this.validatorIDField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class markType : abstractMarkType
    {

        private List<trademarkType> trademarkField;

        private List<treatyOrStatuteType> treatyOrStatuteField;

        private List<courtType> courtField;

        /// <summary>
        /// markType class constructor
        /// </summary>
        public markType()
        {
            //this.courtField = new List<courtType>();
            //this.treatyOrStatuteField = new List<treatyOrStatuteType>();
            //this.trademarkField = new List<trademarkType>();
        }

        [System.Xml.Serialization.XmlElementAttribute("trademark", Order = 0)]
        public List<trademarkType> trademark
        {
            get
            {
                return this.trademarkField;
            }
            set
            {
                this.trademarkField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("treatyOrStatute", Order = 1)]
        public List<treatyOrStatuteType> treatyOrStatute
        {
            get
            {
                return this.treatyOrStatuteField;
            }
            set
            {
                this.treatyOrStatuteField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("court", Order = 2)]
        public List<courtType> court
        {
            get
            {
                return this.courtField;
            }
            set
            {
                this.courtField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class trademarkType : GeneratedEppEntity<trademarkType>
    {

        private string idField;

        private string markNameField;

        private List<holderType> holderField;

        private List<contactType> contactField;

        private string jurisdictionField;

        private List<string> classField;

        private List<string> labelField;

        private string goodsAndServicesField;

        private string apIdField;

        private System.DateTime apDateField;

        private bool apDateFieldSpecified;

        private string regNumField;

        private System.DateTime regDateField;

        private System.DateTime exDateField;

        private bool exDateFieldSpecified;

        /// <summary>
        /// trademarkType class constructor
        /// </summary>
        public trademarkType()
        {
            //this.labelField = new List<string>();
            //this.classField = new List<string>();
            //this.contactField = new List<contactType>();
            //this.holderField = new List<holderType>();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string markName
        {
            get
            {
                return this.markNameField;
            }
            set
            {
                this.markNameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("holder", Order = 2)]
        public List<holderType> holder
        {
            get
            {
                return this.holderField;
            }
            set
            {
                this.holderField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("contact", Order = 3)]
        public List<contactType> contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 4)]
        public string jurisdiction
        {
            get
            {
                return this.jurisdictionField;
            }
            set
            {
                this.jurisdictionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("class", DataType = "integer", Order = 5)]
        public List<string> @class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("label", DataType = "token", Order = 6)]
        public List<string> label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 7)]
        public string goodsAndServices
        {
            get
            {
                return this.goodsAndServicesField;
            }
            set
            {
                this.goodsAndServicesField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 8)]
        public string apId
        {
            get
            {
                return this.apIdField;
            }
            set
            {
                this.apIdField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public System.DateTime apDate
        {
            get
            {
                return this.apDateField;
            }
            set
            {
                this.apDateField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool apDateSpecified
        {
            get
            {
                return this.apDateFieldSpecified;
            }
            set
            {
                this.apDateFieldSpecified = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 10)]
        public string regNum
        {
            get
            {
                return this.regNumField;
            }
            set
            {
                this.regNumField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public System.DateTime regDate
        {
            get
            {
                return this.regDateField;
            }
            set
            {
                this.regDateField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public System.DateTime exDate
        {
            get
            {
                return this.exDateField;
            }
            set
            {
                this.exDateField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool exDateSpecified
        {
            get
            {
                return this.exDateFieldSpecified;
            }
            set
            {
                this.exDateFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class holderType : GeneratedEppEntity<holderType>
    {

        private string nameField;

        private string orgField;

        private addrType addrField;

        private e164Type voiceField;

        private e164Type faxField;

        private string emailField;

        private entitlementType entitlementField;

        private bool entitlementFieldSpecified;

        /// <summary>
        /// holderType class constructor
        /// </summary>
        public holderType()
        {
            //this.faxField = new e164Type();
            //this.voiceField = new e164Type();
            //this.addrField = new addrType();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string org
        {
            get
            {
                return this.orgField;
            }
            set
            {
                this.orgField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public addrType addr
        {
            get
            {
                return this.addrField;
            }
            set
            {
                this.addrField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public e164Type voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public e164Type fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 5)]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public entitlementType entitlement
        {
            get
            {
                return this.entitlementField;
            }
            set
            {
                this.entitlementField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool entitlementSpecified
        {
            get
            {
                return this.entitlementFieldSpecified;
            }
            set
            {
                this.entitlementFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class addrType : GeneratedEppEntity<addrType>
    {

        private List<string> streetField;

        private string cityField;

        private string spField;

        private string pcField;

        private string ccField;

        /// <summary>
        /// addrType class constructor
        /// </summary>
        public addrType()
        {
            //this.streetField = new List<string>();
        }

        [System.Xml.Serialization.XmlElementAttribute("street", DataType = "token", Order = 0)]
        public List<string> street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 2)]
        public string sp
        {
            get
            {
                return this.spField;
            }
            set
            {
                this.spField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 3)]
        public string pc
        {
            get
            {
                return this.pcField;
            }
            set
            {
                this.pcField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 4)]
        public string cc
        {
            get
            {
                return this.ccField;
            }
            set
            {
                this.ccField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class e164Type : GeneratedEppEntity<e164Type>
    {

        private string xField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string x
        {
            get
            {
                return this.xField;
            }
            set
            {
                this.xField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public enum entitlementType
    {

        /// <remarks/>
        owner,

        /// <remarks/>
        assignee,

        /// <remarks/>
        licensee,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class contactType : GeneratedEppEntity<contactType>
    {

        private string nameField;

        private string orgField;

        private addrType addrField;

        private e164Type voiceField;

        private e164Type faxField;

        private string emailField;

        private contactTypeType typeField;

        private bool typeFieldSpecified;

        /// <summary>
        /// contactType class constructor
        /// </summary>
        public contactType()
        {
            //this.faxField = new e164Type();
            //this.voiceField = new e164Type();
            //this.addrField = new addrType();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string org
        {
            get
            {
                return this.orgField;
            }
            set
            {
                this.orgField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public addrType addr
        {
            get
            {
                return this.addrField;
            }
            set
            {
                this.addrField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public e164Type voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public e164Type fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 5)]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public contactTypeType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public enum contactTypeType
    {

        /// <remarks/>
        owner,

        /// <remarks/>
        agent,

        /// <remarks/>
        thirdparty,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class treatyOrStatuteType : GeneratedEppEntity<treatyOrStatuteType>
    {

        private string idField;

        private string markNameField;

        private List<holderType> holderField;

        private List<contactType> contactField;

        private List<protectionType> protectionField;

        private List<string> labelField;

        private string goodsAndServicesField;

        private string refNumField;

        private System.DateTime proDateField;

        private string titleField;

        private System.DateTime execDateField;

        /// <summary>
        /// treatyOrStatuteType class constructor
        /// </summary>
        public treatyOrStatuteType()
        {
            //this.labelField = new List<string>();
            //this.protectionField = new List<protectionType>();
            //this.contactField = new List<contactType>();
            //this.holderField = new List<holderType>();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string markName
        {
            get
            {
                return this.markNameField;
            }
            set
            {
                this.markNameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("holder", Order = 2)]
        public List<holderType> holder
        {
            get
            {
                return this.holderField;
            }
            set
            {
                this.holderField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("contact", Order = 3)]
        public List<contactType> contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("protection", Order = 4)]
        public List<protectionType> protection
        {
            get
            {
                return this.protectionField;
            }
            set
            {
                this.protectionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("label", DataType = "token", Order = 5)]
        public List<string> label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 6)]
        public string goodsAndServices
        {
            get
            {
                return this.goodsAndServicesField;
            }
            set
            {
                this.goodsAndServicesField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 7)]
        public string refNum
        {
            get
            {
                return this.refNumField;
            }
            set
            {
                this.refNumField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public System.DateTime proDate
        {
            get
            {
                return this.proDateField;
            }
            set
            {
                this.proDateField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 9)]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public System.DateTime execDate
        {
            get
            {
                return this.execDateField;
            }
            set
            {
                this.execDateField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class protectionType : GeneratedEppEntity<protectionType>
    {

        private string ccField;

        private string regionField;

        private List<string> rulingField;

        /// <summary>
        /// protectionType class constructor
        /// </summary>
        public protectionType()
        {
            //this.rulingField = new List<string>();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string cc
        {
            get
            {
                return this.ccField;
            }
            set
            {
                this.ccField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ruling", DataType = "token", Order = 2)]
        public List<string> ruling
        {
            get
            {
                return this.rulingField;
            }
            set
            {
                this.rulingField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class courtType : GeneratedEppEntity<courtType>
    {

        private string idField;

        private string markNameField;

        private List<holderType> holderField;

        private List<contactType> contactField;

        private List<string> labelField;

        private string goodsAndServicesField;

        private string refNumField;

        private System.DateTime proDateField;

        private string ccField;

        private List<string> regionField;

        private string courtNameField;

        /// <summary>
        /// courtType class constructor
        /// </summary>
        public courtType()
        {
            //this.regionField = new List<string>();
            //this.labelField = new List<string>();
            //this.contactField = new List<contactType>();
            //this.holderField = new List<holderType>();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string markName
        {
            get
            {
                return this.markNameField;
            }
            set
            {
                this.markNameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("holder", Order = 2)]
        public List<holderType> holder
        {
            get
            {
                return this.holderField;
            }
            set
            {
                this.holderField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("contact", Order = 3)]
        public List<contactType> contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("label", DataType = "token", Order = 4)]
        public List<string> label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 5)]
        public string goodsAndServices
        {
            get
            {
                return this.goodsAndServicesField;
            }
            set
            {
                this.goodsAndServicesField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 6)]
        public string refNum
        {
            get
            {
                return this.refNumField;
            }
            set
            {
                this.refNumField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public System.DateTime proDate
        {
            get
            {
                return this.proDateField;
            }
            set
            {
                this.proDateField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 8)]
        public string cc
        {
            get
            {
                return this.ccField;
            }
            set
            {
                this.ccField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("region", DataType = "token", Order = 9)]
        public List<string> region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 10)]
        public string courtName
        {
            get
            {
                return this.courtNameField;
            }
            set
            {
                this.courtNameField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlIncludeAttribute(typeof(markType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:mark-1.0")]
    public partial class abstractMarkType : GeneratedEppEntity<abstractMarkType>
    {
    }

    [System.Xml.Serialization.XmlIncludeAttribute(typeof(signedMarkType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:signedMark-1.0")]
    public partial class abstractSignedMarkType : GeneratedEppEntity<abstractSignedMarkType>
    {
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:signedMark-1.0")]
    public partial class signedMarkType : abstractSignedMarkType
    {

        private string idField;

        private issuerInfoType issuerInfoField;

        private System.DateTime notBeforeField;

        private System.DateTime notAfterField;

        private markType itemField;

        private SignatureType signatureField;

        private string id1Field;

        /// <summary>
        /// signedMarkType class constructor
        /// </summary>
        public signedMarkType()
        {
            //this.signatureField = new SignatureType();
            //this.itemField = new markType();
            //this.issuerInfoField = new issuerInfoType();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public issuerInfoType issuerInfo
        {
            get
            {
                return this.issuerInfoField;
            }
            set
            {
                this.issuerInfoField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public System.DateTime notBefore
        {
            get
            {
                return this.notBeforeField;
            }
            set
            {
                this.notBeforeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public System.DateTime notAfter
        {
            get
            {
                return this.notAfterField;
            }
            set
            {
                this.notAfterField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("mark", Namespace = "urn:ietf:params:xml:ns:mark-1.0", Order = 4)]
        public markType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 5)]
        public SignatureType Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute("id", DataType = "ID")]
        public string id1
        {
            get
            {
                return this.id1Field;
            }
            set
            {
                this.id1Field = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:signedMark-1.0")]
    public partial class issuerInfoType : GeneratedEppEntity<issuerInfoType>
    {

        private string orgField;

        private string emailField;

        private string urlField;

        private e164Type voiceField;

        private string issuerIDField;

        /// <summary>
        /// issuerInfoType class constructor
        /// </summary>
        public issuerInfoType()
        {
            //this.voiceField = new e164Type();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 0)]
        public string org
        {
            get
            {
                return this.orgField;
            }
            set
            {
                this.orgField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 2)]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public e164Type voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string issuerID
        {
            get
            {
                return this.issuerIDField;
            }
            set
            {
                this.issuerIDField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureType : GeneratedEppEntity<SignatureType>
    {

        private SignedInfoType signedInfoField;

        private SignatureValueType signatureValueField;

        private KeyInfoType keyInfoField;

        private List<ObjectType> objectField;

        private string idField;

        /// <summary>
        /// SignatureType class constructor
        /// </summary>
        public SignatureType()
        {
            //this.objectField = new List<ObjectType>();
            //this.keyInfoField = new KeyInfoType();
            //this.signatureValueField = new SignatureValueType();
            //this.signedInfoField = new SignedInfoType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public SignedInfoType SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SignatureValueType SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public KeyInfoType KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Object", Order = 3)]
        public List<ObjectType> Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoType : GeneratedEppEntity<SignedInfoType>
    {

        private CanonicalizationMethodType canonicalizationMethodField;

        private SignatureMethodType signatureMethodField;

        private List<ReferenceType> referenceField;

        private string idField;

        /// <summary>
        /// SignedInfoType class constructor
        /// </summary>
        public SignedInfoType()
        {
            //this.referenceField = new List<ReferenceType>();
            //this.signatureMethodField = new SignatureMethodType();
            //this.canonicalizationMethodField = new CanonicalizationMethodType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public CanonicalizationMethodType CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SignatureMethodType SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Reference", Order = 2)]
        public List<ReferenceType> Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class CanonicalizationMethodType : GeneratedEppEntity<CanonicalizationMethodType>
    {

        private List<System.Xml.XmlNode> anyField;

        private string algorithmField;

        /// <summary>
        /// CanonicalizationMethodType class constructor
        /// </summary>
        public CanonicalizationMethodType()
        {
            //this.anyField = new List<System.Xml.XmlNode>();
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public List<System.Xml.XmlNode> Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureMethodType : GeneratedEppEntity<SignatureMethodType>
    {

        private string hMACOutputLengthField;

        private List<System.Xml.XmlNode> anyField;

        private string algorithmField;

        /// <summary>
        /// SignatureMethodType class constructor
        /// </summary>
        public SignatureMethodType()
        {
            //this.anyField = new List<System.Xml.XmlNode>();
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        public string HMACOutputLength
        {
            get
            {
                return this.hMACOutputLengthField;
            }
            set
            {
                this.hMACOutputLengthField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 1)]
        public List<System.Xml.XmlNode> Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ReferenceType : GeneratedEppEntity<ReferenceType>
    {

        private List<TransformType> transformsField;

        private DigestMethodType digestMethodField;

        private byte[] digestValueField;

        private string idField;

        private string uRIField;

        private string typeField;

        /// <summary>
        /// ReferenceType class constructor
        /// </summary>
        public ReferenceType()
        {
            //this.digestMethodField = new DigestMethodType();
            //this.transformsField = new List<TransformType>();
        }

        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public List<TransformType> Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public DigestMethodType DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 2)]
        public byte[] DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class TransformType : GeneratedEppEntity<TransformType>
    {

        private List<object> itemsField;

        private List<string> textField;

        private string algorithmField;

        /// <summary>
        /// TransformType class constructor
        /// </summary>
        public TransformType()
        {
            //this.textField = new List<string>();
            //this.itemsField = new List<object>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("XPath", typeof(string), Order = 0)]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public List<string> Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class DigestMethodType : GeneratedEppEntity<DigestMethodType>
    {

        private List<System.Xml.XmlNode> anyField;

        private string algorithmField;

        /// <summary>
        /// DigestMethodType class constructor
        /// </summary>
        public DigestMethodType()
        {
            //this.anyField = new List<System.Xml.XmlNode>();
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public List<System.Xml.XmlNode> Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureValueType : GeneratedEppEntity<SignatureValueType>
    {

        private string idField;

        private byte[] valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class KeyInfoType : GeneratedEppEntity<KeyInfoType>
    {

        private List<object> itemsField;

        private List<ItemsChoiceType2> itemsElementNameField;

        private List<string> textField;

        private string idField;

        /// <summary>
        /// KeyInfoType class constructor
        /// </summary>
        public KeyInfoType()
        {
            //this.textField = new List<string>();
            //this.itemsElementNameField = new List<ItemsChoiceType2>();
            //this.itemsField = new List<object>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("KeyName", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("KeyValue", typeof(KeyValueType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("MgmtData", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PGPData", typeof(PGPDataType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("RetrievalMethod", typeof(RetrievalMethodType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SPKIData", typeof(SPKIDataType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509Data", typeof(X509DataType), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public List<ItemsChoiceType2> ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public List<string> Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class KeyValueType : GeneratedEppEntity<KeyValueType>
    {

        private object itemField;

        private List<string> textField;

        /// <summary>
        /// KeyValueType class constructor
        /// </summary>
        public KeyValueType()
        {
            //this.textField = new List<string>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DSAKeyValue", typeof(DSAKeyValueType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("RSAKeyValue", typeof(RSAKeyValueType), Order = 0)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public List<string> Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class DSAKeyValueType : GeneratedEppEntity<DSAKeyValueType>
    {

        private byte[] pField;

        private byte[] qField;

        private byte[] gField;

        private byte[] yField;

        private byte[] jField;

        private byte[] seedField;

        private byte[] pgenCounterField;

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 0)]
        public byte[] P
        {
            get
            {
                return this.pField;
            }
            set
            {
                this.pField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 1)]
        public byte[] Q
        {
            get
            {
                return this.qField;
            }
            set
            {
                this.qField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 2)]
        public byte[] G
        {
            get
            {
                return this.gField;
            }
            set
            {
                this.gField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 3)]
        public byte[] Y
        {
            get
            {
                return this.yField;
            }
            set
            {
                this.yField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 4)]
        public byte[] J
        {
            get
            {
                return this.jField;
            }
            set
            {
                this.jField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 5)]
        public byte[] Seed
        {
            get
            {
                return this.seedField;
            }
            set
            {
                this.seedField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 6)]
        public byte[] PgenCounter
        {
            get
            {
                return this.pgenCounterField;
            }
            set
            {
                this.pgenCounterField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class RSAKeyValueType : GeneratedEppEntity<RSAKeyValueType>
    {

        private byte[] modulusField;

        private byte[] exponentField;

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 0)]
        public byte[] Modulus
        {
            get
            {
                return this.modulusField;
            }
            set
            {
                this.modulusField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", Order = 1)]
        public byte[] Exponent
        {
            get
            {
                return this.exponentField;
            }
            set
            {
                this.exponentField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class PGPDataType : GeneratedEppEntity<PGPDataType>
    {

        private List<object> itemsField;

        private List<ItemsChoiceType1> itemsElementNameField;

        /// <summary>
        /// PGPDataType class constructor
        /// </summary>
        public PGPDataType()
        {
            //this.itemsElementNameField = new List<ItemsChoiceType1>();
            //this.itemsField = new List<object>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyID", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public List<ItemsChoiceType1> ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        PGPKeyID,

        /// <remarks/>
        PGPKeyPacket,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class RetrievalMethodType : GeneratedEppEntity<RetrievalMethodType>
    {

        private List<TransformType> transformsField;

        private string uRIField;

        private string typeField;

        /// <summary>
        /// RetrievalMethodType class constructor
        /// </summary>
        public RetrievalMethodType()
        {
            this.transformsField = new List<TransformType>();
        }

        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public List<TransformType> Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SPKIDataType : GeneratedEppEntity<SPKIDataType>
    {

        private List<object> itemsField;

        /// <summary>
        /// SPKIDataType class constructor
        /// </summary>
        public SPKIDataType()
        {
            this.itemsField = new List<object>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SPKISexp", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509DataType : GeneratedEppEntity<X509DataType>
    {

        private List<object> itemsField;

        private List<ItemsChoiceType> itemsElementNameField;

        /// <summary>
        /// X509DataType class constructor
        /// </summary>
        public X509DataType()
        {
            this.itemsElementNameField = new List<ItemsChoiceType>();
            this.itemsField = new List<object>();
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509CRL", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509Certificate", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509IssuerSerial", typeof(X509IssuerSerialType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509SKI", typeof(byte[]), DataType = "base64Binary", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("X509SubjectName", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public List<ItemsChoiceType> ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509IssuerSerialType : GeneratedEppEntity<X509IssuerSerialType>
    {

        private string x509IssuerNameField;

        private string x509SerialNumberField;

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string X509IssuerName
        {
            get
            {
                return this.x509IssuerNameField;
            }
            set
            {
                this.x509IssuerNameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        public string X509SerialNumber
        {
            get
            {
                return this.x509SerialNumberField;
            }
            set
            {
                this.x509SerialNumberField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        X509CRL,

        /// <remarks/>
        X509Certificate,

        /// <remarks/>
        X509IssuerSerial,

        /// <remarks/>
        X509SKI,

        /// <remarks/>
        X509SubjectName,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <remarks/>
        KeyName,

        /// <remarks/>
        KeyValue,

        /// <remarks/>
        MgmtData,

        /// <remarks/>
        PGPData,

        /// <remarks/>
        RetrievalMethod,

        /// <remarks/>
        SPKIData,

        /// <remarks/>
        X509Data,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ObjectType : GeneratedEppEntity<ObjectType>
    {

        private List<System.Xml.XmlNode> anyField;

        private string idField;

        private string mimeTypeField;

        private string encodingField;

        /// <summary>
        /// ObjectType class constructor
        /// </summary>
        public ObjectType()
        {
            this.anyField = new List<System.Xml.XmlNode>();
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public List<System.Xml.XmlNode> Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MimeType
        {
            get
            {
                return this.mimeTypeField;
            }
            set
            {
                this.mimeTypeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:signedMark-1.0")]
    public partial class encodedSignedMarkType : GeneratedEppEntity<encodedSignedMarkType>
    {

        private string encodingField;

        private string valueField;

        public encodedSignedMarkType()
        {
            this.encodingField = "base64";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("base64")]
        public string encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class createNoticeType : GeneratedEppEntity<createNoticeType>
    {

        private noticeIDType noticeIDField;

        private System.DateTime notAfterField;

        private System.DateTime acceptedDateField;

        /// <summary>
        /// createNoticeType class constructor
        /// </summary>
        public createNoticeType()
        {
            this.noticeIDField = new noticeIDType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public noticeIDType noticeID
        {
            get
            {
                return this.noticeIDField;
            }
            set
            {
                this.noticeIDField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime notAfter
        {
            get
            {
                return this.notAfterField;
            }
            set
            {
                this.notAfterField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public System.DateTime acceptedDate
        {
            get
            {
                return this.acceptedDateField;
            }
            set
            {
                this.acceptedDateField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class noticeIDType : GeneratedEppEntity<noticeIDType>
    {

        private string validatorIDField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string validatorID
        {
            get
            {
                return this.validatorIDField;
            }
            set
            {
                this.validatorIDField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    public enum objectType
    {

        /// <remarks/>
        application,

        /// <remarks/>
        registration,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("update", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class idContainerType : GeneratedEppEntity<idContainerType>
    {

        private phaseType phaseField;

        private string applicationIDField;

        /// <summary>
        /// idContainerType class constructor
        /// </summary>
        public idContainerType()
        {
            this.phaseField = new phaseType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string applicationID
        {
            get
            {
                return this.applicationIDField;
            }
            set
            {
                this.applicationIDField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("chkData", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class chkDataType : GeneratedEppEntity<chkDataType>
    {

        private phaseType phaseField;

        private List<cdType> cdField;

        /// <summary>
        /// chkDataType class constructor
        /// </summary>
        public chkDataType()
        {
            this.cdField = new List<cdType>();
            this.phaseField = new phaseType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("cd", Order = 1)]
        public List<cdType> cd
        {
            get
            {
                return this.cdField;
            }
            set
            {
                this.cdField = value;
            }
        }

        //public void Extract(XElement extensionElement)
        //{
        //    //var chkDataElement = extensionElement;

        //    //this.phase = new phaseType()
        //    //    {
        //    //        Value = this.ToEnum<phaseTypeValue>(chkDataElement, "name")
        //    //    };

        //    //this.cd = chkDataElement
        //    //    .Elements(SchemaHelper.LaunchNs.GetName("cd"))
        //    //    .Select(e=>new cdType()
        //    //        {
        //    //            claimKey = this.ToEnum<claimKeyType>(e, "claimKey"),
        //    //            name = new cdNameType()
        //    //                {
        //    //                    exists = this.GetAttr<bool>(e, "name", "exists"),
        //    //                    Value = this.GetElemVal<string>(e, "name")
        //    //                }
        //    //        }).ToList();
        //    var c = chkDataType.Deserialize(extensionElement.ToString());
        //    this.phase = c.phase;
        //    this.cd = c.cd;
        //}

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class cdType : GeneratedEppEntity<cdType>
    {

        private cdNameType nameField;

        private claimKeyType claimKeyField;

        /// <summary>
        /// cdType class constructor
        /// </summary>
        public cdType()
        {
            this.claimKeyField = new claimKeyType();
            this.nameField = new cdNameType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public cdNameType name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public claimKeyType claimKey
        {
            get
            {
                return this.claimKeyField;
            }
            set
            {
                this.claimKeyField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class cdNameType : GeneratedEppEntity<cdNameType>
    {

        private bool existsField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool exists
        {
            get
            {
                return this.existsField;
            }
            set
            {
                this.existsField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class claimKeyType : GeneratedEppEntity<claimKeyType>
    {

        private string validatorIDField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string validatorID
        {
            get
            {
                return this.validatorIDField;
            }
            set
            {
                this.validatorIDField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "token")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("infData", Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = false)]
    public partial class infDataType : GeneratedEppEntity<infDataType>
    {

        private phaseType phaseField;

        private string applicationIDField;

        private statusType statusField;

        private List<markType> itemsField;

        /// <summary>
        /// infDataType class constructor
        /// </summary>
        public infDataType()
        {
            this.itemsField = new List<markType>();
            this.statusField = new statusType();
            this.phaseField = new phaseType();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public phaseType phase
        {
            get
            {
                return this.phaseField;
            }
            set
            {
                this.phaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "token", Order = 1)]
        public string applicationID
        {
            get
            {
                return this.applicationIDField;
            }
            set
            {
                this.applicationIDField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public statusType status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("mark", Namespace = "urn:ietf:params:xml:ns:mark-1.0", Order = 3)]
        public List<markType> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0", IsNullable = true)]
    public partial class statusType : GeneratedEppEntity<statusType>
    {

        private statusValueType sField;

        private string langField;

        private string nameField;

        private string valueField;

        public statusType()
        {
            this.langField = "en";
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public statusValueType s
        {
            get
            {
                return this.sField;
            }
            set
            {
                this.sField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
        [System.ComponentModel.DefaultValueAttribute("en")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "normalizedString")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:launch-1.0")]
    public enum statusValueType
    {

        /// <remarks/>
        pendingValidation,

        /// <remarks/>
        validated,

        /// <remarks/>
        invalid,

        /// <remarks/>
        pendingAllocation,

        /// <remarks/>
        allocated,

        /// <remarks/>
        rejected,

        /// <remarks/>
        custom,
    }
}
