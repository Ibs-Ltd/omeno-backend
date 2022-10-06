using Asp.Omeno.Service.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Asp.Omeno.Service.Application.Helpers
{
    public static class ServiceHelper
    {
        private static IServiceCollection _serviceCollection;

        public static void Configure(IServiceCollection services)
        {
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));
        }

        public static IServiceDbContext GetDbContext()
        {
            return _serviceCollection.BuildServiceProvider().GetRequiredService<IServiceDbContext>();
        }

        public static IHttpClientFactory GetHttpClient()
        {
            return _serviceCollection.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();
        }
        
        public static IConfiguration GetConfiguration()
        {
            return _serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
        }
    }
}
