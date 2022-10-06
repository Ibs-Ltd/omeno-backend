using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.DeleteImage
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public DeleteImageCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == request.Id);
            image.Status = false;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
