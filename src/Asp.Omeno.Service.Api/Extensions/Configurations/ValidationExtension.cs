using Asp.Omeno.Service.Application.Services.Users.Commands.Login;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Extensions.Configurations
{
    public static class ValidationExtension
    {
        public static void UseValidations(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining(typeof(LoginCommandValidator));
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
        }
    }
}
