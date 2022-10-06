using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class HttpClientExtension
    {
        public static void RegisterHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("HttpClientWithSSLUntrusted").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            //(httpRequestMessage, cert, cetChain, policyErrors) =>
            //{
            //    return true;
            //}
            });
        }
    }
}
