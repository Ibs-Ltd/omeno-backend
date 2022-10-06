using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ResetPassword
{
    public class ResetPasswordAccountCommandValidator : AbstractValidator<ResetPasswordAccountCommand>
    {
        private readonly IServiceDbContext _dbContext;
        public ResetPasswordAccountCommandValidator(IServiceDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Email"))
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.Email).Must((email) =>
                     {
                         return _dbContext.Users.Any(x => x.Email == email);
                     }).WithMessage(x => ValidatorMessages.NotFound(x.Email));
                 });

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("New Password"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.NewPassword).MinimumLength(Conditions.PasswordMinLength)
                    .WithMessage(ValidatorMessages.MinLength("New Password"));
                });


            RuleFor(x => x.Token).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Token"));
        }
    }
}
