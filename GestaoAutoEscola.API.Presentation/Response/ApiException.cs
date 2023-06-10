﻿namespace GestaoAutoEscola.API.Presentation.Response;
public class ApiException : Exception
{
    public int StatusCode { get; set; }
    public new string StackTrace { get; set; }

    public ApiException(string message, int statusCode = 500)
        : base(message)
    {
        StatusCode = statusCode;
        StackTrace = base.StackTrace!;
    }
}
