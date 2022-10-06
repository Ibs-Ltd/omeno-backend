using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetStatuses
{
    public class GetProductStatusesQuery : IRequest<IList<GetProductStatusesModel>>
    {
    }
}
