using System.Runtime.Serialization;

namespace DynamicMapping.Core.Errors
{
    [DataContract]
    public class ValidationErrorResponse : ErrorResponse
    {
        [DataContract]
        public class ValidationError
        {
            [DataMember]
            public string ErrorCode { get; set; }

            [DataMember]
            public string Message { get; set; }
        }

        public static ValidationErrorResponse Standard => new ValidationErrorResponse
        {
            ErrorCode = null,
            Message = "The request is invalid."
        };

        [DataMember]
        public IDictionary<string, ValidationError> ValidationErrors { get; set; }

        public ValidationErrorResponse()
        {
            base.Type = "ValidationError";
            ValidationErrors = new Dictionary<string, ValidationError>();
        }

        public ValidationErrorResponse WithValidationError(string key, string errorCode, string message)
        {
            ValidationErrors[key] = new ValidationError
            {
                ErrorCode = errorCode,
                Message = message
            };
            return this;
        }
    }
}
