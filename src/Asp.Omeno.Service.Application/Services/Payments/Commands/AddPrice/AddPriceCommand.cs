using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddPrice
{
    public class AddPriceCommand : IRequest<AddPriceModel>
    {
        public long Price { get; set; } 
        public string Currency { get; set; }
        public string ProductId { get; set; }
    }

    public class AddPriceModel
    {
        public string PriceId { get; set; }
    }
}
