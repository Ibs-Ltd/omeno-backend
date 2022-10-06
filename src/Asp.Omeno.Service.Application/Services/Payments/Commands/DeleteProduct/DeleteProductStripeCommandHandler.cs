using MediatR;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.DeleteProduct
{
    public class DeleteProductStripeCommandHandler : IRequestHandler<DeleteProductStripeCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductStripeCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var service = new ProductService();
            service.Delete(request.ProductId);

            return Unit.Value;
        }
    }
}
