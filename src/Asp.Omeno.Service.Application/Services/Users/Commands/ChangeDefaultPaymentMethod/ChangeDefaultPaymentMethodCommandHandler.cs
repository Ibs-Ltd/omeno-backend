using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ChangeDefaultPaymentMethod
{
    public class ChangeDefaultPaymentMethodCommandHandler : IRequestHandler<ChangeDefaultPaymentMethodCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public ChangeDefaultPaymentMethodCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(ChangeDefaultPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var options = new CustomerUpdateOptions
            {
                InvoiceSettings = new CustomerInvoiceSettingsOptions
                {
                    DefaultPaymentMethod = request.CardId
                }
            };

            var service = new CustomerService();
            service.Update(user.StripeCustomerId, options);

            return Unit.Value;
        }
    }
}
