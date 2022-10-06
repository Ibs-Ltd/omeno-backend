using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
