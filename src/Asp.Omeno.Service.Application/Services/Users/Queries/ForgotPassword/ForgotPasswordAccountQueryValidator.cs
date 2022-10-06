using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using FluentValidation;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword
{
    public class ForgotPasswordAccountQueryValidator : AbstractValidator<ForgotPasswordAccountQuery>
    {
        private readonly IServiceDbContext _dbContext;
        public ForgotPasswordAccountQueryValidator(IServiceDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Email"))
                .DependentRules(() => {
                    RuleFor(x => x.Email).Must((email) =>
                    {
                        return _dbContext.Users.Any(x => x.Email == email);
                    }).WithMessage(x => ValidatorMessages.NotFound(x.Email));
                });
        }
    }
}
