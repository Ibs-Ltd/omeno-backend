using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.PayInvoice
{
    public class PayInvoiceCommandHandler : IRequestHandler<PayInvoiceCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public PayInvoiceCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(PayInvoiceCommand request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var servicePrice = new PriceService();
            var priceResponse = servicePrice.Get(request.Price);

            var optionsPaymentMethod = new PaymentMethodListOptions
            {
                Customer = user.StripeCustomerId,
                Type = "card",      
            };
            var servicePaymentMethod = new PaymentMethodService();
            StripeList<PaymentMethod> paymentMethods = servicePaymentMethod.List(
                optionsPaymentMethod
            );

            var getCustomer = new CustomerService();
            var customerResult = getCustomer.Get(user.StripeCustomerId);

            var invoiceItems = new InvoiceItemCreateOptions
            {
                Customer = customerResult.Id,     
                Price = priceResponse.Id,
                
                
            };
            var invoiceItemsService = new InvoiceItemService();
            var invoiceItemResult = invoiceItemsService.Create(invoiceItems);

            var options = new InvoiceCreateOptions
            {
                Customer = user.StripeCustomerId,
                AutoAdvance = true,
                CollectionMethod = "charge_automatically",
                DefaultPaymentMethod = paymentMethods.Where(x => x.Id == customerResult.InvoiceSettings.DefaultPaymentMethodId).FirstOrDefault().Id,  
                
            };
            var invoiceService = new InvoiceService();
            var result = invoiceService.Create(options);


            var invoiceFinalizeOptions = new InvoiceFinalizeOptions { AutoAdvance = true };
            var serviceInvoiceFinalize = new InvoiceService();
            var finalizeResponse = serviceInvoiceFinalize.FinalizeInvoice(result.Id, invoiceFinalizeOptions);


            var response = invoiceService.Pay(finalizeResponse.Id, new InvoicePayOptions
            {
                PaymentMethod = paymentMethods.Where(x => x.Id == customerResult.InvoiceSettings.DefaultPaymentMethodId).FirstOrDefault().Id,
                
            });
            

            if (result.Paid)
            {
                var serviceProduct = new ProductService();
                var productResponse = serviceProduct.Get(priceResponse.ProductId);

                user.Tokens += Convert.ToInt64(productResponse.Name);
                await _context.SaveChangesAsync();
            }
            
            return Unit.Value;
        }
    }
}
