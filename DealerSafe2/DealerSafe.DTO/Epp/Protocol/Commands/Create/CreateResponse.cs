namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic create response class
    /// </summary>
    /// <typeparam name="TCreateResult">Target create result class (represents object specific "creData" element in response) </typeparam>
    [Serializable]
    public class CreateResponse<TCreateResult> : ResponseBase<TCreateResult>
        where TCreateResult : class, ICommandResult<TCreateResult>, new()
    {
        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected override string ResultElementName
        {
            get { return "creData"; }
        }
    }
}