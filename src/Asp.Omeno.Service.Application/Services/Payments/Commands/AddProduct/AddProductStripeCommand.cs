using MediatR;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddProduct
{
    public class AddProductStripeCommand : IRequest<AddProductStripeModel>
    {
        public long Price { get; set; }
        public string Currency { get; set; }
        public string ProductName { get; set; }
        public string ProductIndex { get; set; }
    }

    public class AddProductStripeModel
    {
        public string PriceId { get; set; }
        public string ProductId { get; set; }
    }
}
