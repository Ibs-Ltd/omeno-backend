using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.PayInvoice
{
    public class PayInvoiceCommand : IRequest
    {
        public string Price { get; set; }
    }
}
