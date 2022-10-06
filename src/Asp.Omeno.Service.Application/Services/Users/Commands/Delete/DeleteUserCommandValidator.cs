using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IServiceDbContext _context;
        public DeleteUserCommandValidator(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }

        public void Validations()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("User"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserId).Must((Id) =>
                    {
                        return _context.Users.Any(x => x.Id == Id);
                    }).WithMessage(ValidatorMessages.NotFound("This User"));
                });
        }
    }
}
