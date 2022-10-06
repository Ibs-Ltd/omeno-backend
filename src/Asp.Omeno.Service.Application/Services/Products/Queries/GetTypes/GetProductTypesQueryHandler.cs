using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetTypes
{
    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, IList<GetProductTypesModel>>
    {
        private readonly IServiceDbContext _context;
        public GetProductTypesQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetProductTypesModel>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProductTypes.Select(type => new GetProductTypesModel
            {
                Id = type.Id,
                Name = type.Name
            }).ToListAsync();
        }
    }
}
