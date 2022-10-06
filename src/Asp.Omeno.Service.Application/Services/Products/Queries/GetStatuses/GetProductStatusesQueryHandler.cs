using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetStatuses
{
    public class GetProductStatusesQueryHandler : IRequestHandler<GetProductStatusesQuery, IList<GetProductStatusesModel>>
    {
        private readonly IServiceDbContext _context;
        public GetProductStatusesQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetProductStatusesModel>> Handle(GetProductStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProductStatuses.Select(status => new GetProductStatusesModel
            {
                Id = status.Id,
                Name = status.Name
            }).ToListAsync();
        }
    }
}
