namespace GestaoAutoEscola.API.Presentation.Response;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; } = default!;
    public Exception? Error { get; set; }
    public string? Message { get; set; }
    public int? StatusCode { get; set; }
    public string? StackTrace { get; set; }
    public ApiResponse(bool isSuccess, T data, Exception? error = null, string? message = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        Message = message;
    }

    public ApiResponse(bool isSuccess, int? statusCode, string? message = null, string? strackTrace = null)
    {
        IsSuccess = isSuccess;
        StackTrace = strackTrace;
        Message = message;
        StatusCode = statusCode;
    }

    public ApiResponse(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }
}

