using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IList<ProductModel>>
    {
        private readonly IServiceDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public GetProductQueryHandler(IServiceDbContext context, IMemoryCache memoryCache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public async Task<IList<ProductModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var productsFromCache = (IList<ProductModel>)_memoryCache.Get(InMemoryCacheKeysEnum.PRODUCTS);

            IList<ProductModel> products = new List<ProductModel>();
            if (productsFromCache == null)
            {
                products = await _context.Products
                    .Include(x => x.Bids)
                    .Where(x => x.ProductStepId == ProductEnum.PRODUCT_STEP_CURRENT)
                    .Select(product => new ProductModel
                {
                    Id = product.Id,
                    Active = product.Active,
                    TimeNow = DateTime.UtcNow,
                    Name = product.Name,
                    Timer = product.Counter,
                    TimerFromDb = product.Counter,
                    Price = product.Price,
                    StartTime = product.StartTime,
                    EndTime = product.EndTime,
                    Index = product.Index,
                    Biders = product.Bids.Select(bid => new BidModel
                    {
                        UserId = bid.UserId,
                        FirstName = bid.User.FirstName,
                        LastName = bid.User.LastName,
                        UserName = bid.User.UserName,
                        IsLast = bid.IsLast
                    }).ToList(),
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
                }).ToListAsync();
            }
            else
            {
                var shouldAnyRemove = productsFromCache.Where(x => x.Step.Id == ProductEnum.PRODUCT_STEP_UPCOMING).ToList();
                if(shouldAnyRemove.Count > 0)
                {
                    foreach(var productToRemove in shouldAnyRemove)
                    {
                        productsFromCache.Remove(productToRemove);
                    }
                    
                }

                products = productsFromCache;
              
                var selectNewFromDb = await _context.Products
                    .Where(x => x.ProductStepId == ProductEnum.PRODUCT_STEP_CURRENT)
                    .Where(x => !productsFromCache.Select(y => y.Id).Contains(x.Id)).Select(newProduct => new ProductModel
                {
                    Id = newProduct.Id,
                    Name = newProduct.Name,
                    Timer = newProduct.Counter,
                    TimerFromDb = newProduct.Counter,
                    Price = newProduct.Price,
                    StartTime = newProduct.StartTime,
                    EndTime = newProduct.EndTime,
                    Index = newProduct.Index,
                    Biders = newProduct.Bids.Select(bid => new BidModel
                    {
                        UserId = bid.UserId,
                        FirstName = bid.User.FirstName,
                        LastName = bid.User.LastName,
                        UserName = bid.User.UserName,
                        IsLast = bid.IsLast
                    }).ToList(),
                    FirstImageId = newProduct.FirstImageId,
                    Status = new ProductStatusModel
                    {
                        Id = newProduct.ProductStatus.Id,
                        Name = newProduct.ProductStatus.Name
                    },
                    Type = new ProductTypeModel
                    {
                        Id = newProduct.ProductType.Id,
                        Name = newProduct.ProductType.Name
                    },
                    Step = new ProductStepModel
                    {
                        Id = newProduct.ProductStep.Id,
                        Name = newProduct.ProductStep.Name
                    },
                    Images = newProduct.ProductImages.Select(image => new ProductImagesModel
                    {
                        Id = image.ImageId,
                        FileName = image.Image.FileName,
                        Url = image.Image.Url
                    }).ToList(),
                }).ToListAsync();

                foreach (var newProduct in selectNewFromDb)
                {
                    products.Add(newProduct);
                }
            }

            _memoryCache.Set(InMemoryCacheKeysEnum.PRODUCTS, products);
            return products.OrderBy(x => x.Index).ToList();
        }
    }
}
