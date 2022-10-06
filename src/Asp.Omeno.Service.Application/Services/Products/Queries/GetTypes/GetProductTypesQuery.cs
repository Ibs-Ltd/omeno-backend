using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetTypes
{
    public class GetProductTypesQuery : IRequest<IList<GetProductTypesModel>>
    {
    }
}
