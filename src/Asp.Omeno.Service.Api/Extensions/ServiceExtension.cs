using Asp.Omeno.Service.Api.Extensions.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(configuration);
            services.RegisterCors();
            services.RegisterIdentityServer(configuration);
            services.RegisterAuthentication(configuration);
            services.RegisterHealthCheck();
            services.RegisterSwagger();
            services.RegisterMediator();
            services.RegisterHttpClient();
            services.RegisterHelpers();
            return services;
        }

        public static IMvcBuilder UseServices(this IMvcBuilder builder)
        {
            builder.UseValidations();

            return builder;
        }
        public static IApplicationBuilder AddServices(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseRegisteredCors();
            app.UseRegisteredHealthCheck();
            app.UseRegisteredSwagger();
            app.UseRegisteredHelpers();
            StripeExtension.UseRegisteredAuthenticationStripe(configuration);
            return app;
        }
    }
}
