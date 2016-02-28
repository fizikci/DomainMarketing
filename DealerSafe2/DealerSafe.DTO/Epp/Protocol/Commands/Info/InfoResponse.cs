namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Base class for all info responses 
    /// </summary>
    /// <typeparam name="TInfoResult">Target info result class (represents object specific "infData" element in response)</typeparam>
    [Serializable]
    public class InfoResponse<TInfoResult> : ResponseBase<TInfoResult>
        where TInfoResult : class, ICommandResult<TInfoResult>, new()
    {
        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected override string ResultElementName
        {
            get { return "infData"; }
        }
    }
}