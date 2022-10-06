using Asp.Omeno.Service.Application.Infrastructure.Mediator;
using Asp.Omeno.Service.Application.Services.Users.Commands.Login;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class MediatorExtension
    {
        public static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(LoginCommand).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }
    }
}
