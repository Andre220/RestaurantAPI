using System.Net;

namespace RestaurantWeb.Middlewares
{
    public class UnhandledExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UnhandledExceptionsMiddleware> _logger;

        public UnhandledExceptionsMiddleware(RequestDelegate next, ILogger<UnhandledExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro interno no servidor."
            }.ToString());
        }
    }
}
