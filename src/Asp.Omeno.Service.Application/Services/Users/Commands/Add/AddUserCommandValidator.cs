using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Add
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IServiceDbContext _context;

        public AddUserCommandValidator(IServiceDbContext context)
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
        }
    }
}
