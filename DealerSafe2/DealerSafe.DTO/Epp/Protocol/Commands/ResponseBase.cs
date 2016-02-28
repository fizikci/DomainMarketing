namespace Epp.Protocol.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Base class for all responses 
    /// </summary>
    /// <typeparam name="TCommandResult">Target info data class (represents object specific result element in response)</typeparam>
    [Serializable]
    public abstract class ResponseBase<TCommandResult> : IResponse
        where TCommandResult : class, ICommandResult<TCommandResult>, new()
    {
        /// <summary>
        /// The command result XML element 
        /// </summary>
        [NonSerialized]
        private XElement resultElement;

        /// <summary>
        /// Gets the command result object
        /// </summary>
        public TCommandResult Result { get; set; }

        /// <summary>
        /// Gets collection of response extensions
        /// </summary>
        public List<object> Extensions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected abstract string ResultElementName { get; }

        #region IResponse Members

        /// <summary>
        /// Extracts info response content from the underlying response message
        /// </summary>
        /// <param name="response">Response message</param>
        public virtual void ExtractResult(ResponseMessageBase response)
        {
            this.resultElement = response.ResponseDataElement
                .Elements()
                .Where(elem => elem.Name.LocalName == this.ResultElementName)
                .FirstOrDefault();

            if (this.resultElement == null)
            {
                throw new ArgumentException(String.Format("\"resData\" element must contain specific \"{0}\" element", this.ResultElementName));
            }

            this.Extensions = response.Extensions.ToList();

            this.Result = new TCommandResult();

            this.Result.ExtractResult(this);
        }

        #endregion

        /// <summary>
        /// Extracts object specific response extension
        /// </summary>
        /// <typeparam name="T">Target extension type</typeparam>
        /// <returns>Object specific response extension</returns>
        public T Extension<T>() where T : IResponseExtension, new()
        {
            return this.Extensions.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns command result XML element 
        /// </summary>
        /// <returns>Command result XML element </returns>
        public XElement GetResultElement()
        {
            return this.resultElement;
        }
    }
}