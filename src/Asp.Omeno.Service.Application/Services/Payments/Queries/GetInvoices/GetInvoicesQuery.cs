using MediatR;
using Stripe;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetInvoices
{
    public class GetInvoicesQuery : IRequest<StripeList<Invoice>>
    {
    }
}
