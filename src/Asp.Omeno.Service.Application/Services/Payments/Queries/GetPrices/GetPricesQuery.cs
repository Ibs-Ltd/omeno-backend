using MediatR;
using Stripe;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetPrices
{
    public class GetPricesQuery : IRequest<StripeList<Price>>
    {
    }
}
