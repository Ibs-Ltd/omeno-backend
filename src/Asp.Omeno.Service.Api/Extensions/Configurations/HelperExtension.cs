using Asp.Omeno.Service.Application.Helpers;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class HelperExtension
    {
        public static void RegisterHelpers(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPushNotification, PushNotification>();
            ServiceHelper.Configure(services);
        }

        public static void UseRegisteredHelpers(this IApplicationBuilder app)
        {
            IHttpContextAccessor httpContext = app.ApplicationServices.GetService<IHttpContextAccessor>();

            AuthHelper.Configure(httpContext);
        }
    }
}
