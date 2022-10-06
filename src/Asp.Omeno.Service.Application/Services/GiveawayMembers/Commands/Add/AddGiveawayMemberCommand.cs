using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using Asp.Omeno.Service.Common.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.GiveawayMembers.Commands.Add
{
    public class AddGiveawayMemberCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string UserName { get; set; }
    }

    public class AddGiveawayMemberCommandValidator : AbstractValidator<AddGiveawayMemberCommand>
    {
        private readonly IServiceDbContext _context;
        public AddGiveawayMemberCommandValidator(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }

        private void Validations()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Product"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.ProductId).Must((id) =>
                    {
                        return _context.Products.Where(x => x.ProductTypeId == ProductEnum.PRODUCT_TYPE_GIVEAWAY).Any(x => x.Id == id);
                    }).WithMessage(x => ValidatorMessages.NotFound("Product"));
                });

            RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("UserName"))
                .DependentRules(() =>
                {
                    RuleFor(x => new { x.UserName, x.ProductId}).Must((request) =>
                    {
                        return !_context.GiveawayMembers.Where(x => x.ProductId == request.ProductId).Any(x => x.Member == request.UserName);
                    }).WithMessage(x => ValidatorMessages.AlreadyExists(x.UserName));
                });
        }
    }
}
