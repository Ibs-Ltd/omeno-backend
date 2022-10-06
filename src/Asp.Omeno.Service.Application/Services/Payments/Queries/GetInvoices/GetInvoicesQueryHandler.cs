using MediatR;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Queries.GetInvoices
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, StripeList<Invoice>>
    {
        public async Task<StripeList<Invoice>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            var options = new InvoiceListOptions{};
            var service = new InvoiceService();
            StripeList<Invoice> invoices = service.List(
              options
            );

            return invoices;
        }
    }
}
