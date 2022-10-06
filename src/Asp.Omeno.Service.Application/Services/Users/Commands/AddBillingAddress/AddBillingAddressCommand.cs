using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.AddBillingAddress
{
    public class AddBillingAddressCommand : IRequest
    {
        public string AddressName { get;set;}
        public string AddressNameTwo { get;set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
