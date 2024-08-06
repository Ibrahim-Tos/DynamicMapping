using System.Runtime.Serialization;

namespace DynamicMapping.Core.Errors
{
    public class ErrorResponse
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
