using AlymSoftGo.Domain.Common;

namespace AlymSoftGo.Domain.DTOs
{
    public class ErrorDto
    {
        public ResponseCode Code { get; set; } = ResponseCode.UnexpectedError;
        public string Message { get; set; } = string.Empty;
        public object? Details { get; set; }
        public string? ErrorReference { get; set; }
    }
}
