using AlymSoftGo.Domain.Common;

namespace AlymSoftGo.Domain.Exceptions
{
    public class SPBusinessException : Exception
    {
        public int ResponseType { get; }
        public string ResponseCode { get; }
        public ResponseCode EnumCode { get; }
        public object? Errors { get; }

        public SPBusinessException(ResponseCode enumCode, string responseCode, string message = "", int responseType = 3, object? errors = null) 
            : base(string.IsNullOrEmpty(message) ? (string.IsNullOrEmpty(responseCode) ? enumCode.ToString() : responseCode) : message)
        {
            ResponseType = responseType;
            ResponseCode = string.IsNullOrEmpty(responseCode) ? enumCode.ToString() : responseCode;
            EnumCode = enumCode;
            Errors = errors;
        }
    }
}
