using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.DeleteProduct
{
    public class DeleteProductStripeCommand : IRequest
    {
        public string ProductId { get; set; }
    }
}
