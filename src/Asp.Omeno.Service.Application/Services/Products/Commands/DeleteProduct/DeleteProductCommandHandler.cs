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

namespace Asp.Omeno.Service.Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        HubConnection connection;
        public DeleteProductCommandHandler(IServiceDbContext context, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            connection = new HubConnectionBuilder()
                  .WithUrl(_configuration["Endpoints:Service"] + "/product")
                  .Build();
            await connection.StartAsync();
            var productsFromCache = (IList<ProductModel>)_memoryCache.Get(InMemoryCacheKeysEnum.PRODUCTS);

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            product.Status = false;

            if(productsFromCache != null)
            {
                var selectProductFromCache = productsFromCache.FirstOrDefault(x => x.Id == request.Id);
                productsFromCache.Remove(selectProductFromCache);
            }
            

            await _context.SaveChangesAsync();
            await connection.InvokeAsync("GetProducts");

            return Unit.Value;
        }
    }
}
