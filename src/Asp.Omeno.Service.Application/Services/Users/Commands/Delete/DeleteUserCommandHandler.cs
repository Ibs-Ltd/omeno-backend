using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public DeleteUserCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
