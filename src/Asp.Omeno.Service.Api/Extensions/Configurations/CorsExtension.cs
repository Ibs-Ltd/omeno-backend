using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class CorsExtension
    {
        private static ILoggerFactory _logger = new LoggerFactory();
        public static string corsPolicyName = "SiteCorsPolicy";
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName, builder =>
                {
                    builder.WithOrigins("http://localhost:8080", "http://localhost:8081", "https://admin.omeno.app").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            var cors = new DefaultCorsPolicyService(_logger.CreateLogger<DefaultCorsPolicyService>())
            {
                AllowedOrigins = { "http://localhost:8080", "http://localhost:8081", "https://admin.omeno.app" },
                AllowAll = true
            };

            services.AddSingleton<ICorsPolicyService>(cors);
        }

        public static void UseRegisteredCors(this IApplicationBuilder app)
        {
            app.UseCors(corsPolicyName);
        }
    }

}
