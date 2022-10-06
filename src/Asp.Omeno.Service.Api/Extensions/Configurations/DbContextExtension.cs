using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class DbContextExtension
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("OmenoDatabase");

            services.AddDbContext<ServiceDbContext>(options => options.UseMySql(connectionString));

            services.AddScoped<IServiceDbContext, ServiceDbContext>();
        }
    }
}
