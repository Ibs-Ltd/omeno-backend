using MediatR;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddPrice
{
    public class AddPriceCommandHandler : IRequestHandler<AddPriceCommand, AddPriceModel>
    {
        public async Task<AddPriceModel> Handle(AddPriceCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var options = new PriceCreateOptions
            {
                UnitAmount = request.Price,
                Currency = request.Currency,
                Product = request.ProductId,
            };
            var service = new PriceService();
            var result = service.Create(options);

            return new AddPriceModel
            {
                PriceId = result.Id
            };
        }
    }
}
