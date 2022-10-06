using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<GetAllProductsModel>>
    {
        private readonly IServiceDbContext _context;
        public GetAllProductsQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetAllProductsModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = from product in _context.Products
                         select product;

            if (request.Filter != null)
            {
                result = QueryConditionsFilter(request, result);
            }

            return await result
                .Select(product => new GetAllProductsModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    StartTime = product.StartTime,
                    EndTime = product.EndTime,
                    Active = product.Active,
                    Index = product.Index,
                    FirstImageId = product.FirstImageId,
                    Status = new ProductStatus
                    {
                        Id = product.ProductStatus.Id,
                        Name = product.ProductStatus.Name
                    },
                    Type = new ProductType
                    {
                        Id = product.ProductType.Id,
                        Name = product.ProductType.Name
                    },
                    Step = new ProductStep
                    {
                        Id = product.ProductStep.Id,
                        Name = product.ProductStep.Name
                    },
                    Images = product.ProductImages.Select(image => new ProductImages
                    {
                        Id = image.ImageId,
                        FileName = image.Image.FileName,
                        Url = image.Image.Url
                    }).ToList(),
                    Members = product.GiveawayMembers.Select(member => new GiveawayMembers
                    {
                        Id = member.Id,
                        UserName = member.Member
                    }).ToList(),
                    CreatedAt = product.CreatedAt
                }).Skip((request.Page - 1) * request.RowsPerPage)
                .Take(request.RowsPerPage).ToListAsync();
        }

        private static IQueryable<Product> QueryConditionsFilter(GetAllProductsQuery request, IQueryable<Product> result)
        {
            bool isAnyFound = false;

            string[] words = Regex.Split(request.Filter, @"\W+");
            foreach (string value in words)
            {
                if (value != "")
                {
                    if (result.Any(x => x.NormalizedName.Contains(value.ToUpper())))
                    {
                        result = result.Where(x => x.NormalizedName.Contains(value.ToUpper()));
                        isAnyFound = true;
                    }

                    if (result.Any(x => x.Description.Contains(value.ToUpper())))
                    {
                        result = result.Where(x => x.Description.Contains(value.ToUpper()));
                        isAnyFound = true;
                    }
                }

            }

            if (isAnyFound == false)
                result = result.Where(x => x.Name == "NO USERS AVAILABLE");
            return result;
        }
    }
}
