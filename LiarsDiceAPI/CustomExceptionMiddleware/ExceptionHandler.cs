using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using LiarsDiceAPI.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LiarsDiceAPI.CustomExceptionMiddleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext /* other dependencies */)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // default value=500 

            if (ex is NotFoundException)
                code = HttpStatusCode.NotFound;
            else if (ex is BadRequestException)
                code = HttpStatusCode.BadRequest;

            var message = code == HttpStatusCode.InternalServerError
                ? "An unexpected error occurred"
                : JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(message);
        }
    }
}