using Microsoft.Extensions.Configuration;
using Stripe;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class StripeExtension
    {
        public static void UseRegisteredAuthenticationStripe(IConfiguration configuration)
        {
            StripeConfiguration.ApiKey = configuration["Authentication:SecretStripe"];
        }
    }
}
