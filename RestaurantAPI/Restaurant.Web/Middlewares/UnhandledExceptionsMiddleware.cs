using RestaurantWeb.Helpers;
using System.Net;

namespace RestaurantWeb.Middlewares
{
    public class UnhandledExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public UnhandledExceptionsMiddleware(RequestDelegate next)
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
                Log.LogError($"Erro: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new
            {
                context.Response.StatusCode,
                Message = "Ocorreu um erro interno no servidor."
            }.ToString());
        }
    }
}
