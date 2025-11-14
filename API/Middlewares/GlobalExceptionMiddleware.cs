using System.Net;
using System.Text.Json;
using Shared.Utils;

namespace API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is CustomException customEx)
            {
                context.Response.StatusCode = (int)customEx.HttpStatusCode;

                var result = JsonSerializer.Serialize(
                    new { message = customEx.Message, status = customEx.HttpStatusCode }
                );

                await context.Response.WriteAsync(result);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var genericResult = JsonSerializer.Serialize(
                new { message = $"Erro interno no servidor: {ex.Message}", status = 500 }
            );

            await context.Response.WriteAsync(genericResult);
        }
    }
}
