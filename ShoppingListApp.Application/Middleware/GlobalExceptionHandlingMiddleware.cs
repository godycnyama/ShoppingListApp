using Microsoft.AspNetCore.Http;
using ShoppingListApp.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace ShoppingListApp.Application.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;
        ResponseModel exModel = new ResponseModel();

        switch (exception)
        {
            case ApplicationException ex:
                exModel.ResponseCode = (int)HttpStatusCode.BadRequest;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                exModel.ResponseMessage = ex.Message;
                break;

            case ShoppingItemNotFoundException ex:
                exModel.ResponseCode = (int)HttpStatusCode.NotFound;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                exModel.ResponseMessage = ex.Message;
                break;

            case ShoppingListNotFoundException ex:
                exModel.ResponseCode = (int)HttpStatusCode.NotFound;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                exModel.ResponseMessage = ex.Message;
                break;

            case ShoppingListsNotFoundException ex:
                exModel.ResponseCode = (int)HttpStatusCode.NotFound;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                exModel.ResponseMessage = ex.Message;
                break;

            case FileNotFoundException ex:
                exModel.ResponseCode = (int)HttpStatusCode.NotFound;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                exModel.ResponseMessage = ex.Message;
                break;
            default:
                exModel.ResponseCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                exModel.ResponseMessage = "Internal Server Error, Please retry after sometime";
                break;

        }
        var exResult = JsonSerializer.Serialize(exModel);
        await context.Response.WriteAsync(exResult);
    }
}
