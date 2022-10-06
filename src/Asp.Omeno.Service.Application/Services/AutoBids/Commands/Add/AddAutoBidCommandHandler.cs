using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.AutoBids.Commands.Add
{
    public class AddAutoBidCommandHandler : IRequestHandler<AddAutoBidCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public AddAutoBidCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddAutoBidCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Id == request.User_ID);

            if(user != null)
            {
                var autobid = request.AddNewAutoBid();
                _context.AutoBids.Add(autobid);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else throw new BadRequestException("UserId is not available");

            return Unit.Value;
        }
    }
}
