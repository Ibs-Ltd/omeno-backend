using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.Total
{
    public class GetTotalProductsQueryHandler : IRequestHandler<GetTotalProductsQuery, int>
    {
        private readonly IServiceDbContext _context;
        public GetTotalProductsQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> Handle(GetTotalProductsQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Products.ToListAsync();

            return users.Count;
        }
    }
}
