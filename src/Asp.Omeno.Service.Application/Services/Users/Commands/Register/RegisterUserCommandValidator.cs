using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IServiceDbContext _context;

        public RegisterUserCommandValidator(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Validations();
        }

        private void Validations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Email")).DependentRules(() =>
            {
                RuleFor(x => x.Email).Matches(ValidatorRegex.Email).WithMessage(ValidatorMessages.FormatNotMatch("Email")).DependentRules(() =>
                {
                    RuleFor(x => x.Email).MustAsync(async (email, cancellation) =>
                    {
                        return !await _context.Users.AsNoTracking().IgnoreQueryFilters().AnyAsync(x => x.Email.ToLower() == email.ToLower(), cancellation);
                    }).WithMessage(x => ValidatorMessages.AlreadyExists(x.Email));
                });
            });

            RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("UserName")).DependentRules(() =>
            {
                RuleFor(x => x.UserName).Matches(ValidatorRegex.UserName).WithMessage(ValidatorMessages.FormatNotMatch("UserName")).DependentRules(() =>
                {
                    RuleFor(x => x.UserName).MustAsync(async (UserName, cancellation) =>
                    {
                        return !await _context.Users.AsNoTracking().IgnoreQueryFilters().AnyAsync(x => x.UserName.ToLower() == UserName.ToLower(), cancellation);
                    }).WithMessage(x => ValidatorMessages.AlreadyExists(x.UserName));
                });
            });

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("First Name"));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Last Name"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Password"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password).MinimumLength(Conditions.PasswordMinLength)
                    .WithMessage(ValidatorMessages.MinLength("Password"));
                });
        }
    }
}
