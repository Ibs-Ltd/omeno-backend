using Asp.Omeno.Service.Domain.Entities.Identity;
using Asp.Omeno.Service.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class IdentityServerExtension
    {
        public static void RegisterIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(IdentityServerDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("AuthDatabase");

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ServiceDbContext>().AddDefaultTokenProviders();

            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               .AddOperationalStore(options =>
               options.ConfigureDbContext = builder =>
               builder.UseMySql(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
               .AddConfigurationStore(options =>
               options.ConfigureDbContext = builder =>
               builder.UseMySql(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
               .AddAspNetIdentity<User>();
        }
    }
}
