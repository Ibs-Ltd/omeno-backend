using MediatR;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddProduct
{
    public class AddProductStripeCommandHandler : IRequestHandler<AddProductStripeCommand, AddProductStripeModel>
    {
        public async Task<AddProductStripeModel> Handle(AddProductStripeCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            var options = new ProductCreateOptions
            {
                Name = request.ProductName,
                Description = request.ProductIndex
            };
            var service = new ProductService();
            var product = service.Create(options);

            var priceOptions = new PriceCreateOptions
            {
                UnitAmount = request.Price,
                Currency = request.Currency,
                Product = product.Id,
            };
            var priceService = new PriceService();
            var priceResult = priceService.Create(priceOptions);
            return new AddProductStripeModel
            {
                PriceId = priceResult.Id,
                ProductId = product.Id
            };
        }
    }
}
