using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        HubConnection connection;
        public UpdateProductCommandHandler(IServiceDbContext context, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            connection = new HubConnectionBuilder()
               .WithUrl(_configuration["Endpoints:Service"] + "/product")
               .Build();
            await connection.StartAsync();
            var productsFromCache = (IList<ProductModel>)_memoryCache.Get(InMemoryCacheKeysEnum.PRODUCTS);
            
            

            var product = await _context.Products
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            var productToUpdate = request.UpdateProduct(product);
            
            var imagesToAdd = request.UpdateProductImages(product.ProductImages, _context);

            _context.Products.Update(productToUpdate);
            _context.ProductImages.AddRange(imagesToAdd);
            if (productsFromCache.Count > 0)
            {
                var selectProductFromCache = productsFromCache.FirstOrDefault(x => x.Id == request.Id);
                    selectProductFromCache.Name = productToUpdate.Name;
                    selectProductFromCache.Price = productToUpdate.Price;
                    selectProductFromCache.StartTime = productToUpdate.StartTime;
                    selectProductFromCache.EndTime = productToUpdate.EndTime;
                    selectProductFromCache.FirstImageId = productToUpdate.FirstImageId;
                    selectProductFromCache.Step.Id = productToUpdate.ProductStepId;
                    selectProductFromCache.Active = productToUpdate.Active;
                    selectProductFromCache.Index = productToUpdate.Index;
                    
            }
            
            await _context.SaveChangesAsync();  
            _memoryCache.Set(InMemoryCacheKeysEnum.PRODUCTS, productsFromCache);      
            await connection.InvokeAsync("GetProducts");

            return Unit.Value;
        }

    }
}
