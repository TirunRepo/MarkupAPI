namespace Markup.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(T data, string? message = null)
        {
            Success = true;
            Data = data;
            Message = message;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public static ApiResponse<T> Ok(T data, string? message = null)
        {
            return new ApiResponse<T>(data, message);
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>(message) { Success = false };
        }
    }
}
