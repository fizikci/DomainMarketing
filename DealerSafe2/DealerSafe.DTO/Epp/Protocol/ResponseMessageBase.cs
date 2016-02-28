namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the response message
    /// </summary>
    [Serializable]
    public class ResponseMessageBase : MessageBase
    {
        /// <summary>
        /// Collection of response extensions
        /// </summary>
        private readonly List<object> extensions;

        /// <summary>
        /// Initializes a new instance of the ResponseMessageBase class.
        /// </summary>
        /// <param name="messageDocument">Message body</param>
        public ResponseMessageBase(XDocument messageDocument)
            : base(messageDocument, MessageType.Response)
        {
            this.Results = this.ResponseElement
                .Elements(EppNs.GetName("result"))
                .Select(resElement => new ResponseResult(resElement))
                .ToList().AsReadOnly();

            var idElem = this.ResponseElement.Element(EppNs.GetName("trID"));
            if (idElem == null)
            {
                return;
            }

            var clientTRIDElem = idElem.Element(EppNs.GetName("clTRID"));
            this.ClientTranId = (clientTRIDElem == null) ? null : clientTRIDElem.Value;

            var serviceIdElem = idElem.Element(EppNs.GetName("svTRID"));
            this.ServerTranId = (serviceIdElem == null) ? null : serviceIdElem.Value;

            var msgQElement = this.ResponseElement.Element(EppNs.GetName("msgQ"));
            if (msgQElement != null)
            {
                this.MessageQueue = new ResponseMessageQueue(msgQElement);
            }

            var extensionElement = this.ResponseElement.Element(EppNs.GetName("extension"));
            if (extensionElement != null)
            {
                this.extensions = extensionElement
                    .Elements()
                    .Select(objElem => ExtensionManager.CreateObject(objElem))
                    .Where(obj => obj != null)
                    .ToList();
            }
            else
            {
                this.extensions = new List<object>();
            }
        }


        /// <summary>
        /// Gets a list of response results
        /// </summary>
        public IList<ResponseResult> Results { get; set; }

        /// <summary>
        /// Gets a the first response result. In major cases it is a single result
        /// </summary>
        public ResponseResult Result
        {
            get
            {
                return this.Results[0];
            }
        }

        /// <summary>
        /// Gets the error message if command was not succeeded
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                if (this.CommandSucceeded)
                {
                    return String.Empty;
                }

                return String.Format("{0}. {1}", this.Result.Message, this.Result.Reason);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the command for this response accepted (or succeeded)
        /// </summary>
        public bool CommandSucceeded
        {
            get
            {
                return this.Result.Code / 1000 == 1;
            }
        }

        /// <summary>
        /// Gets response message queue
        /// </summary>
        public ResponseMessageQueue MessageQueue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets client transaction identifier
        /// </summary>
        public string ClientTranId { get; set; }

        /// <summary>
        /// Gets a server transaction identifier
        /// </summary>
        public string ServerTranId { get; set; }

        /// <summary>
        /// Gets "resData" XML element
        /// </summary>
        public XElement ResponseDataElement
        {
            get
            {
                return this.ResponseElement.Element(EppNs.GetName("resData"));
            }
        }

        /// <summary>
        /// Gets collection of response extensions
        /// </summary>
        public List<object> Extensions
        {
            get
            {
                return this.extensions.AsEnumerable().ToList();
            }
        }

        /// <summary>
        /// Gets the string representation of object specific response extension
        /// </summary>
        /// <returns>String representation of object specific response extension</returns>
        public string ExtensionAsString
        {
            get
            {
                var extensionElement = this.ResponseElement.Element(EppNs.GetName("extension"));
                if (extensionElement == null)
                {
                    return String.Empty;
                }

                return extensionElement.Value;
            }
        }

        /// <summary>
        /// Gets "response" XML element
        /// </summary>
        private XElement ResponseElement
        {
            get
            {
                return this.EppElement.Element(EppNs.GetName("response"));
            }
        }

        /// <summary>
        /// Extracts object specific response extension
        /// </summary>
        /// <typeparam name="T">Target extension type</typeparam>
        /// <returns>Object specific response extension</returns>
        public T Extension<T>() where T : IResponseExtension, new()
        {
            return this.extensions.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Return string summary of the message, used in Demo Application
        /// </summary>
        /// <returns>Summary string</returns>
        public override string ToSummaryString()
        {
            var summBuilder = new StringBuilder();
            summBuilder.AppendLine("Response:");
            summBuilder.AppendLine("\tResults:");
            foreach (var result in this.Results)
            {
                summBuilder.AppendFormat("\t\tCode: {0}\n", result.Code);
                summBuilder.AppendFormat("\t\tMessage: {0}\n", result.Message);
                summBuilder.AppendFormat("\t\tLanguage: {0}\n", result.Language);
            }

            summBuilder.AppendFormat("\tClientTranId: {0}\n", this.ClientTranId);
            summBuilder.AppendFormat("\tServerTranId: {0}\n", this.ServerTranId);

            summBuilder.AppendLine();
            summBuilder.Append(base.ToSummaryString());
            return summBuilder.ToString();
        }

        #region Nested type: ResponseMessageQueue

        /// <summary>
        /// Represents messages queued for client retrieval
        /// </summary>
        [Serializable]
        public class ResponseMessageQueue
        {
            /// <summary>
            /// Initializes a new instance of the ResponseMessageQueue class
            /// </summary>
            /// <param name="msgQElement">"msgQ" XML element</param>
            internal ResponseMessageQueue(XElement msgQElement)
            {
                XElement queueDateElem = msgQElement.Element(SchemaHelper.EppNs.GetName("qDate"));
                this.QueueDate = queueDateElem == null ? (DateTime?)null : DateTime.Parse(queueDateElem.Value);

                XElement msgElement = msgQElement.Element(SchemaHelper.EppNs.GetName("msg"));
                this.Message = msgElement == null ? null : msgElement.Value;

                this.Count = Int32.Parse(msgQElement.Attribute("count").Value);

                this.MessageId = msgQElement.Attribute("id").Value;
            }

            /// <summary>
            /// Gets the date and time that the message was enqueued
            /// </summary>
            public DateTime? QueueDate { get; set; }

            /// <summary>
            /// Gets human-readable message
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Gets the number of messages that exist in the queue
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// Gets unique identifier of the message at the head of the queue
            /// </summary>
            public string MessageId { get; set; }
        }

        #endregion

        #region Nested type: ResponseResult

        /// <summary>
        /// Represents single response result
        /// </summary>
        [Serializable]
        public class ResponseResult
        {
            /// <summary>
            /// Initializes a new instance of the ResponseResult class
            /// </summary>
            /// <param name="resultElement">XML element responsed from the server</param>
            internal ResponseResult(XElement resultElement)
            {
                this.Code = Int32.Parse(resultElement.Attribute("code").Value);

                var msgElement = resultElement.Element(EppNs.GetName("msg"));
                var langAttr = msgElement.Attribute("lang");
                this.Language = langAttr == null ? "en" : langAttr.Value;
                this.Message = msgElement.Value;

                var extraMessages = resultElement.Elements(EppNs.GetName("value"));
                if (extraMessages != null && extraMessages.Count() > 0)
                {
                    this.ExtraMessages = new List<string>();
                    foreach (var extraMessage in extraMessages)
                    {
                        var text = extraMessage.Element(EppNs.GetName("text"));
                        if(text!=null)
                            this.ExtraMessages.Add(text.Value);
                    }
                }

                var extValueElement = resultElement.Element(EppNs.GetName("extValue"));
                if (extValueElement != null)
                {
                    var reasonElement = extValueElement.Element(EppNs.GetName("reason"));
                    this.Reason = (reasonElement == null) ? null : reasonElement.Value;
                }
            }


            /// <summary>
            /// Gets result code
            /// </summary>
            public int Code { get; set; }

            /// <summary>
            /// Gets the language of the result message
            /// </summary>
            public string Language { get; set; }

            /// <summary>
            /// Gets the human-readable description of the response code
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Gets human-readable message that describes the reason for the error
            /// </summary>
            public string Reason { get; set; }

            public List<string> ExtraMessages { get; set; }
        }

        #endregion
    }
}