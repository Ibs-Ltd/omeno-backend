using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class CacheExtension
    {
        public static void RegisterSessions(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
        }

        public static void AddSessions(this IApplicationBuilder app)
        {
            app.UseSession();
        }
    }
}
