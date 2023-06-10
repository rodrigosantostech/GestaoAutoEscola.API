using GestaoAutoEscola.API.Presentation.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace GestaoAutoEscola.API.CrossCutting;
public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var apiResponse = new ApiResponse<object>(false, null!, "Ocorreu um erro durante a solicitação.");

        if (exception is ApiException apiException)
        {
            apiResponse.IsSuccess = false;
            apiResponse.StatusCode = apiException.StatusCode;
            statusCode = apiException.StatusCode;
            apiResponse.Message = apiException.Message;
            apiResponse.StackTrace = apiException.StackTrace;
        }
        else if (exception is ValidationException validationException)
        {
            apiResponse.IsSuccess = false;
            apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            statusCode = (int)HttpStatusCode.BadRequest;
            apiResponse.Message = validationException.Message;
            apiResponse.StackTrace = validationException.StackTrace;
        }
        else
        {
            apiResponse.IsSuccess = false;
            apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            statusCode = (int)HttpStatusCode.InternalServerError;
            apiResponse.Message = exception.Message;
            apiResponse.StackTrace = exception.StackTrace;
        }

        var result = JsonConvert.SerializeObject(apiResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(result);
    }
}
