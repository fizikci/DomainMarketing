namespace Epp.Protocol
{
    using System;

    /// <summary>
    /// Command types
    /// </summary>
    [Serializable]
    public enum CommandType
    {
        /// <summary>
        /// Login command
        /// </summary>
        Login = 0,

        /// <summary>
        /// Logout command
        /// </summary>
        Logout = 1,

        /// <summary>
        /// Check command
        /// </summary>
        Check = 2,

        /// <summary>
        /// Info command
        /// </summary>
        Info = 3,

        /// <summary>
        /// Delete command
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Update command
        /// </summary>
        Update = 5,

        /// <summary>
        /// Renew command
        /// </summary>
        Renew = 6,

        /// <summary>
        /// Transfer command
        /// </summary>
        Transfer = 7,

        /// <summary>
        /// Poll command
        /// </summary>
        Poll = 8,
    }
}