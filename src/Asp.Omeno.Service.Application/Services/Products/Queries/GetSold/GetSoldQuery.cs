using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetSold
{
    public class GetSoldQuery : IRequest<IList<ProductModel>>
    {
    }
    //public class GetSoldModel
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //}
}