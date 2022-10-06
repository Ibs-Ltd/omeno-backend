using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductModel>
    {
        private readonly IServiceDbContext _context;
        private readonly IConfiguration _configuration;
        HubConnection connection;
        public AddProductCommandHandler(IServiceDbContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<AddProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            connection = new HubConnectionBuilder()
               .WithUrl(_configuration["Endpoints:Service"] + "/product")
               .Build();
            await connection.StartAsync();
            var product = request.AddProduct();
            var productImages = request.AddProductImage(product.Id);
            _context.Products.Add(product);
            _context.ProductImages.AddRange(productImages);
            await _context.SaveChangesAsync(cancellationToken);
            await connection.InvokeAsync("GetProducts");
            return new AddProductModel
            {
                ProductId = product.Id,
                CreatedAt = product.CreatedAt
            };
        }
    }
}
