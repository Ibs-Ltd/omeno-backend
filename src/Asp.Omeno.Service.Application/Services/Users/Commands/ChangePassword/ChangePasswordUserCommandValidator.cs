using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordUserCommandValidator : AbstractValidator<ChangePasswordUserCommand>
    {
        private readonly IServiceDbContext _context;
        public ChangePasswordUserCommandValidator(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Old Password"));

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("New Password"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.NewPassword).MinimumLength(Conditions.PasswordMinLength)
                    .WithMessage(ValidatorMessages.MinLength("New Password"));
                });
        }
    }
}
