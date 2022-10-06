using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
