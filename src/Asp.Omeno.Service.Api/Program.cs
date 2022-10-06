using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Asp.Omeno.Service.Persistence;
using IdentityServer4.EntityFramework.DbContexts;

namespace Asp.Omeno.Service.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = (ServiceDbContext)scope.ServiceProvider.GetRequiredService(typeof(ServiceDbContext));
                var configurationContext = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                var persistedContext = scope.ServiceProvider.GetService<PersistedGrantDbContext>();
                dbContext.Database.Migrate();
                configurationContext.Database.Migrate();
                persistedContext.Database.Migrate();
                IdentityServerDbContextInitializer.Initialize(configurationContext);
                ServiceDbContextInitializer.Initialize(dbContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            }).ConfigureLogging((hostingContext, logging) =>
            {

                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();

            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseKestrel();
                webBuilder.UseIIS();
            });
    }
}
