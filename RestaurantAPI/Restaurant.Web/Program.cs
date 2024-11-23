using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RestaurantWeb.Middlewares;

namespace RestaurantWeb
{
    public static class Program
    {
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

            ConfigureCoreServices(builder.Services);

            var app = builder.Build();

            ConfigurePipeline(app);

            app.Run();

        }

        static void ConfigureCoreServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        static void ConfigurePipeline(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<UnhandledExceptionsMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute(
                name: "api",
                pattern: "api/{controller}/{action}/{id?}"
            );
        }
    }
}
