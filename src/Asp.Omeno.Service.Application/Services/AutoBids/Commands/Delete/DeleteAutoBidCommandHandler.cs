using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.AutoBids.Commands.Delete
{
    public class DeleteAutoBidCommandHandler : IRequestHandler<DeleteAutoBidCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public DeleteAutoBidCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(DeleteAutoBidCommand request, CancellationToken cancellationToken)
        {         
            
            var autoBid = await _context.AutoBids.Where(x => x.UserId == request.User_ID).FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
            if (autoBid != null)
            {
                autoBid.ProductId = request.ProductId;
                autoBid.Status = false;
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            else throw new BadRequestException("autoBid product is not available for above mentioned user_id");
            
            return Unit.Value;
        }
    }
}
