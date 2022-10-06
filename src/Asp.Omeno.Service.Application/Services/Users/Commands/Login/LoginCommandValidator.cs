using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IServiceDbContext _context;

        public LoginCommandValidator(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Validations();
        }

        private void Validations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Email"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email).Must((email) =>
                    {
                        if (ValidatorRegex.MatchRegex(ValidatorRegex.Email, email))
                        {
                            return _context.Users.Any(x => x.Email.ToUpper() == email.ToUpper());
                        }
                        else
                        {
                            return _context.Users.Any(x => x.UserName.ToUpper() == email.ToUpper());
                        }
                    }).WithMessage(x => ValidatorMessages.NotFound(x.Email));
                });

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Password"));
        }
    }
}
