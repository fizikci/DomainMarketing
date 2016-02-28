namespace Epp.Protocol.Commands
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Generic response message
    /// </summary>
    /// <typeparam name="TResponse">Target response class</typeparam>
    [Serializable]
    public class ResponseMessage<TResponse> : ResponseMessageBase, IResponseMessage
        where TResponse : IResponse, new()
    {
        /// <summary>
        /// Initializes a new instance of the ResponseMessage class with specified response document
        /// </summary>
        /// <param name="responseDocument">Кesponse document</param>
        public ResponseMessage(XDocument responseDocument)
            : base(responseDocument)
        {
            if (this.ResponseDataElement != null)
            {
                this.Response = new TResponse();
                this.Response.ExtractResult(this);
            }
        }


        /// <summary>
        /// Gets the response data object
        /// </summary>
        public TResponse Response
        {
            get;
            set;
        }

        public IResponse GetResponse()
        {
            return Response;
        }
    }

    public interface IResponseMessage
    {
        IResponse GetResponse();
    }
}