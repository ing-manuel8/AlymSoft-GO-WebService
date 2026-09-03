namespace AlymSoftGo.Domain.DTOs
{
    public class ErrorDto
    {
        public int ResponseType { get; set; } = 3;
        public string ResponseCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public object? Details { get; set; }
    }
}
