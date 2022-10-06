using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.UpdatePriceStart
{
    public class UpdatePriceStartCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }     
        public double PriceStart { get; set; }
        public Product UpdateProduct(Product product)
        {
            product.Id = Id;
            product.PriceStart = PriceStart;
            return product;
        }

   }
}
