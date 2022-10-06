using MediatR;
using Stripe;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetStripeProducts
{
    public class GetStripeProductsQuery : IRequest<StripeList<Product>>
    {
    }
}
