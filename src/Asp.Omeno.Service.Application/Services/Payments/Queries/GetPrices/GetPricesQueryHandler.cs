using MediatR;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetPrices
{
    public class GetPricesQueryHandler : IRequestHandler<GetPricesQuery, StripeList<Price>>
    {
        public async Task<StripeList<Price>> Handle(GetPricesQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var options = new PriceListOptions { Active = true };
            var service = new PriceService();
            StripeList<Price> prices = service.List(options);

            return prices;
        }
    }
}
