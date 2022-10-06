using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ChangeDefaultPaymentMethod
{
    public class ChangeDefaultPaymentMethodCommand : IRequest
    {
        public string CardId { get; set; }
    }
}
