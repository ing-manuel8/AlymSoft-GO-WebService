using AlymSoftGo.Domain.Common;

namespace AlymSoftGo.Domain.Exceptions
{
    public class SPBusinessException : Exception
    {
        public ResponseCode ResponseCode { get; }
        public object? Errors { get; }

        public SPBusinessException(ResponseCode responseCode, string message = "", object? errors = null) 
            : base(string.IsNullOrEmpty(message) ? responseCode.ToString() : message)
        {
            ResponseCode = responseCode;
            Errors = errors;
        }
    }
}
