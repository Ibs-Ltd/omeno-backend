using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetSold
{
    public class GetSoldQueryHandler : IRequestHandler<GetSoldQuery, IList<ProductModel>>
    {
        private readonly IServiceDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public GetSoldQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<ProductModel>> Handle(GetSoldQuery request, CancellationToken cancellationToken)
        {
            var sold = from product in _context.Products
                       where product.ProductStatusId == ProductEnum.PRODUCT_STATUS_SOLD
                       select product;
            return await sold
               .Select(product => new ProductModel
               {
                   Id = product.Id                    
               }).ToListAsync();
        }
    }
    
}
