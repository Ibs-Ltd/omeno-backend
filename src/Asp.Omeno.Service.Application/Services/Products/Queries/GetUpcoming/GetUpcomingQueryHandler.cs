using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Asp.Omeno.Service.Common.Enums;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetUpcoming
{
    public class GetUpcomingQueryHandler : IRequestHandler<GetUpcomingQuery, IList<GetUpcomingModel>>
    {
        private readonly IServiceDbContext _context;
        public GetUpcomingQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetUpcomingModel>> Handle(GetUpcomingQuery request, CancellationToken cancellationToken)
        {
            var result = from product in _context.Products
                         select product;

            return await result
                .Where(x => x.ProductStepId == ProductEnum.PRODUCT_STEP_UPCOMING)
                .Select(product => new GetUpcomingModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    StartTime = product.StartTime,
                    EndTime = product.EndTime,
                    Index = product.Index,
                    FirstImageId = product.FirstImageId,
                    Status = new ProductStatusModel
                    {
                        Id = product.ProductStatus.Id,
                        Name = product.ProductStatus.Name
                    },
                    Type = new ProductTypeModel
                    {
                        Id = product.ProductType.Id,
                        Name = product.ProductType.Name
                    },
                    Step = new ProductStepModel
                    {
                        Id = product.ProductStep.Id,
                        Name = product.ProductStep.Name
                    },
                    Images = product.ProductImages.Select(image => new ProductImagesModel
                    {
                        Id = image.ImageId,
                        FileName = image.Image.FileName,
                        Url = image.Image.Url
                    }).ToList(),
                    CreatedAt = product.CreatedAt
                }).ToListAsync();
        }
    }
}
