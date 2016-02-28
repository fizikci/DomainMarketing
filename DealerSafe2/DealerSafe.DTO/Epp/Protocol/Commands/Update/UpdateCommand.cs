namespace Epp.Protocol.Commands
{
    using System;

    /// <summary>
    /// Generic update command class
    /// </summary>
    /// <typeparam name="TUpdateArgs">Target update class (represents object specific "update" element in command)</typeparam>
    [Serializable]
    public class UpdateCommand<TUpdateArgs> : CommandBase<TUpdateArgs>
        where TUpdateArgs : class, ICommandArgs<TUpdateArgs>
    {
         /// <summary>
        /// Initializes a new instance of the UpdateCommand class with specified create object
        /// </summary>
        /// <param name="args">Update object</param>
        public UpdateCommand(TUpdateArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets the name of the command specific element
        /// </summary>
        protected override string CommandElementName
        {
            get { return "update"; }
        }
    }
}
