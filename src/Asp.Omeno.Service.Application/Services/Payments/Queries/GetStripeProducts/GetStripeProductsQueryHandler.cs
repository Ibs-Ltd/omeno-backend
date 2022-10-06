using MediatR;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetStripeProducts
{
    public class GetStripeProductsQueryHandler : IRequestHandler<GetStripeProductsQuery, StripeList<Product>>
    {
        public async Task<StripeList<Product>> Handle(GetStripeProductsQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var options = new ProductListOptions
            {
                Active = true
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(
              options
            );

            return products;
        }
    }
}
