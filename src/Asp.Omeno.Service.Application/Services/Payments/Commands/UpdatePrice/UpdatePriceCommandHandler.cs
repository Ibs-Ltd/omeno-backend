using MediatR;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdatePrice
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, Unit>
    {
        public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var options = new PriceUpdateOptions
            {
                Active = request.Active
            };
            var service = new PriceService();
            service.Update(
              request.PriceId,
              options
            );

            return Unit.Value;
        }
    }
}
