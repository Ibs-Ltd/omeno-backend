using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class HealthCheckExtension
    {
        public static void RegisterHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
        public static void UseRegisteredHealthCheck(this IApplicationBuilder builder)
        {
            builder.UseHealthChecks("/health");
        }
    }
}
