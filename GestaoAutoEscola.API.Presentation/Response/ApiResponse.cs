namespace GestaoCondo.API.Presentation.Response;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; } = default!;
    public Exception? Error { get; set; }
    public string? Message { get; set; }

    public ApiResponse(bool isSuccess, T data, Exception? error = null, string? message = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        Message = message;
    }

    public ApiResponse(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }
}

