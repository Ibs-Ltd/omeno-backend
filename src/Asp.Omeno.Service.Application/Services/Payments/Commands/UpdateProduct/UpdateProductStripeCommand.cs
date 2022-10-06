using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateProduct
{
    public class UpdateProductStripeCommand : IRequest
    {
        public string ProductId { get; set; }
        public string ProductIndex { get; set; }
        public bool Active { get; set; }
    }
}
