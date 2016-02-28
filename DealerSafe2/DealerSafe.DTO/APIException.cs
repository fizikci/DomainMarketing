using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    [Serializable]
    public class APIException : Exception
    {
        public ErrorTypes ErrorType { get; set; }
        public ErrorCodes ErrorCode { get; set; }
        public List<string> ExtraMessages { get; set; }

        public APIException(string message)
            : base(message)
        {
            
        }

        public APIException(string message, ErrorTypes errorType)
            : base(message)
        {
            this.ErrorType = errorType;
        }
        public APIException(string message, ErrorCodes errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
        public APIException(string message, ErrorTypes errorType, ErrorCodes errorCode)
            : base(message)
        {
            this.ErrorType = errorType;
            this.ErrorCode = errorCode;
        }
        public APIException(string message, ErrorTypes errorType, ErrorCodes errorCode, List<string> extraMessages )
            : this(message, errorType, errorCode)
        {
            this.ExtraMessages = extraMessages;
        }

        public APIException(string message, ErrorTypes errorType, ErrorCodes errorCode, Exception inner)
            : base(message, inner)
        {
            this.ErrorType = errorType;
            this.ErrorCode = errorCode;
        }

        protected APIException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public enum ErrorTypes
    {
        SystemError,
        ValidationError
    }

    public enum ErrorCodes
    {
        None,
        UnauthorizedAccess,
        ValidationError,
        TransferPasswordServiceNotResponse = 1000,
        // EPP errors
        UnknownCommand = 2000,
        CommandSyntaxError = 2001,
        CommandUseError = 2002,
        RequiredParameterMissing = 2003,
        ParameterValueRangeError = 2004,
        ParameterValueSyntaxError = 2005,
        UnimplementedProtocolVersion = 2100,
        UnimplementedCommand = 2101,
        UnimplementedOption = 2102,
        UnimplementedExtension = 2103,
        BillingFailure = 2104,
        ObjectIsNotEligibleForRenewal = 2105,
        ObjectIsNotEligibleForTransfer = 2106,
        AuthenticationError = 2200,
        AuthorizationError = 2201,
        InvalidAuthorizationInformation = 2202,
        ObjectPendingTransfer = 2300,
        ObjectNotPendingTransfer = 2301,
        ObjectExists = 2302,
        ObjectDoesNotExist = 2303,
        ObjectStatusProhibitsOperation = 2304,
        ObjectAssociationProhibitsOperation = 2305,
        ParameterValuePolicyError = 2306,
        UnimplementedObjectService = 2307,
        DataManagementPolicyViolation = 2308,
        CommandFailed = 2400,
        CommandFailedServerClosingConnection = 2500,
        AuthenticationErrorServerClosingConnection = 2501,
        SessionLimitExceededServerClosingConnection = 2502,
    }

}
