using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using BSBESales.DTOs;

namespace BSBESales.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var response = ex switch
        {
            DbUpdateException => CreateResponse(
                HttpStatusCode.BadRequest,
                "Database operation failed",
                "DbUpdateException"),

            MySqlException => CreateResponse(
                HttpStatusCode.InternalServerError,
                "Database connection error",
                "MySqlException"),

            KeyNotFoundException => CreateResponse(
                HttpStatusCode.NotFound,
                "Resource not found",
                "NotFound"),

            UnauthorizedAccessException => CreateResponse(
                HttpStatusCode.Unauthorized,
                "Unauthorized access",
                "Unauthorized"),

            ArgumentException => CreateResponse(
                HttpStatusCode.BadRequest,
                ex.Message,
                "ArgumentException"),

            _ => CreateResponse(
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred",
                "ServerError")
        };

        context.Response.StatusCode = response.StatusCode;

        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }

    private ApiErrorResponse CreateResponse(
        HttpStatusCode statusCode,
        string message,
        string errorType)
    {
        return new ApiErrorResponse
        {
            StatusCode = (int)statusCode,
            Message = _env.IsDevelopment() ? message : "Something went wrong",
            ErrorType = errorType,
            TraceId = Guid.NewGuid().ToString()
        };
    }
}