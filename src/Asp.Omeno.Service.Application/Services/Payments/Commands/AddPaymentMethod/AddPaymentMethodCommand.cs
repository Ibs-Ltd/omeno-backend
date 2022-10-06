using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommand : IRequest
    {
        public string Number { get; set; }
        public long ExpMonth { get; set; }
        public long ExpYear { get; set; }
        public string Cvc { get; set; }
        public string Holder { get; set; }
        public string AddressName { get; set; }
        public string AddressNameTwo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
