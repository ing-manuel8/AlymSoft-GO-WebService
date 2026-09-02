namespace AlymSoftGo.Domain.Common
{
    public class RepositoryResponse<T>
    {
        public ResponseCode ResponseCode { get; set; } = ResponseCode.Ok;
        public int ResponseType { get; set; } = 1;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public object? Errors { get; set; }

        public bool IsSuccess => ResponseType == 1 && ResponseCode == ResponseCode.Ok;

        public static RepositoryResponse<T> FromSuccess(T data, string message = "Ok") => new()
        {
            ResponseType = 1,
            ResponseCode = ResponseCode.Ok,
            Message = message,
            Data = data
        };

        public static RepositoryResponse<T> FromError(ResponseCode code, string message, int responseType = 3, object? errors = null) => new()
        {
            ResponseType = responseType,
            ResponseCode = code,
            Message = message,
            Data = default,
            Errors = errors
        };
    }
}
