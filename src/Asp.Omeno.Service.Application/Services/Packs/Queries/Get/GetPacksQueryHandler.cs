using MediatR;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Packs.Queries.Get
{
    public class GetPacksQueryHandler : IRequestHandler<GetPacksQuery, IList<GetPacksModel>>
    {
        public async Task<IList<GetPacksModel>> Handle(GetPacksQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            var optionsPrice = new PriceListOptions { Active = true };
            var servicePrice = new PriceService();
            StripeList<Price> prices = servicePrice.List(optionsPrice);

            var options = new ProductListOptions
            {
                Active = true
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(
              options
            );

            IList<GetPacksModel> packs = new List<GetPacksModel>();

            for(var i = 0; i< products.Data.Count; i++)
            {
                packs.Add(new GetPacksModel {
                    Index = Convert.ToInt32(products.Data[i].Description),
                    MenosAmount = products.Data[i].Name,
                    PriceAmount = prices.Data.Where(x => x.ProductId == products.Data[i].Id).FirstOrDefault().UnitAmount,
                    PriceId = prices.Data.Where(x => x.ProductId == products.Data[i].Id).FirstOrDefault().Id,
                    Currency = prices.Data.Where(x => x.ProductId == products.Data[i].Id).FirstOrDefault().Currency
                });
            }

            return packs;
        }
    }
}
