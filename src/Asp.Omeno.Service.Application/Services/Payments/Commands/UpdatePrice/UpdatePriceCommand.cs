using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdatePrice
{
    public class UpdatePriceCommand : IRequest
    {
        public string PriceId { get; set; }
        public bool Active { get; set; }
    }
}
