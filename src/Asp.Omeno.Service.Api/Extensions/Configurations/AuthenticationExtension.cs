using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class AuthenticationExtension
    {
        public static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var schema = configuration["Authentication:Schema"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = schema;
                options.DefaultChallengeScheme = schema;
            }).AddOAuth2Introspection(options =>
            {
                options.Authority = configuration["Authentication:Authority"];
                options.DiscoveryPolicy.RequireHttps = bool.Parse(configuration["Authentication:RequireHttpsMetadata"]);
                options.ClientId = configuration["Authentication:Audience"];
                options.ClientSecret = configuration["Authentication:ApiSecret"];
                options.RoleClaimType = ClaimTypes.Role;
                options.IntrospectionEndpoint = configuration["Endpoints:Service"] + "/connect/introspect";
            });
        }
    }
}
