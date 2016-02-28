namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic check response class
    /// </summary>
    /// <typeparam name="TCheckResult">Target check result class (represents object specific "chkData" element in response) </typeparam>
    [Serializable]
    public class CheckResponse<TCheckResult> : ResponseBase<TCheckResult>
        where TCheckResult : class, ICommandResult<TCheckResult>, new()
    {
        /// <summary>
        /// Gets the name of the response specific element
        /// </summary>
        protected override string ResultElementName
        {
            get { return "chkData"; }
        }
    }
}