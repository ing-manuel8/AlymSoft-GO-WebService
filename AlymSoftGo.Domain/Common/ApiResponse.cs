namespace AlymSoftGo.Domain.Common
{
    public class ApiResponse
    {
        public ResponseCode Code { get; set; } = ResponseCode.Ok;
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public object? Errors { get; set; }

        public bool IsSuccess => Code == ResponseCode.Ok;
        public bool IsError => Code != ResponseCode.Ok;

        public static ApiResponse Success(object? data = null, string message = "Operation successful") => new()
        {
            Code = ResponseCode.Ok,
            StatusCode = 200,
            Message = message,
            Data = data
        };

        public static ApiResponse Fail(ResponseCode code, string message, int statusCode = 400, object? errors = null) => new()
        {
            Code = code,
            StatusCode = statusCode,
            Message = message,
            Errors = errors
        };
    }
}
