using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetSteps
{
    public class GetProductStepsQueryHandler : IRequestHandler<GetProductStepsQuery, IList<GetProductStepsModel>>
    {
        private readonly IServiceDbContext _context;
        public GetProductStepsQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetProductStepsModel>> Handle(GetProductStepsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProductSteps.Select(type => new GetProductStepsModel
            {
                Id = type.Id,
                Name = type.Name
            }).ToListAsync();
        }
    }
}
