using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetCreditCards
{
    public class GetCreditCardsQueryHandler : IRequestHandler<GetCreditCardsQuery, GetCreditCardModel>
    {
        private readonly IServiceDbContext _context;
        public GetCreditCardsQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetCreditCardModel> Handle(GetCreditCardsQuery request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

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

            return new GetCreditCardModel {
                PaymentMethods = paymentMethods,
                DefaultPaymentMethod = customerResult.InvoiceSettings.DefaultPaymentMethodId
            };
        }
    }

    public class GetCreditCardModel
    {
        public StripeList<PaymentMethod> PaymentMethods { get; set; }
        public string DefaultPaymentMethod { get; set; }
    }
}
