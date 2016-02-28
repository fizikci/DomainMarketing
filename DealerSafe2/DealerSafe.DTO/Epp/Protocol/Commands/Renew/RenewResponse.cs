namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Base class for all renew responses 
    /// </summary>
    /// <typeparam name="TRenewResult">Target renew result class (represents object specific "renData" element in response)</typeparam>
    [Serializable]
    public class RenewResponse<TRenewResult> : ResponseBase<TRenewResult>
        where TRenewResult : class, ICommandResult<TRenewResult>, new()
    {
        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected override string ResultElementName
        {
            get { return "renData"; }
        }
    }
}