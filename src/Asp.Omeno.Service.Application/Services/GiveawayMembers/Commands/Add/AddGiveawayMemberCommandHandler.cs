using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.GiveawayMembers.Commands.Add
{
    public class AddGiveawayMemberCommandHandler : IRequestHandler<AddGiveawayMemberCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public AddGiveawayMemberCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddGiveawayMemberCommand request, CancellationToken cancellationToken)
        {
            var giveawayMember = new GiveawayMember
            {
                Id = Guid.NewGuid(),
                Member = request.UserName,
                ProductId = request.ProductId,
            };
            _context.GiveawayMembers.Add(giveawayMember);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
