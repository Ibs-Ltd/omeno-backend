using MediatR;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateProduct
{
    public class UpdateProductStripeCommandHandler : IRequestHandler<UpdateProductStripeCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateProductStripeCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var options = new ProductUpdateOptions
            {
                Description = request.ProductIndex,
                Active = request.Active
            };
            var service = new ProductService();
            service.Update(request.ProductId, options);
            return Unit.Value;
        }
    }
}
