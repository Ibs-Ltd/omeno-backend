using Asp.Omeno.Service.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.Get
{
    public class GetProductQuery : IRequest<IList<ProductModel>>
    {
    }
}
