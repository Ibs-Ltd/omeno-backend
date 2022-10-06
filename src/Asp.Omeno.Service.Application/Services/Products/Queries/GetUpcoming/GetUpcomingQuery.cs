using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetUpcoming
{
    public class GetUpcomingQuery : IRequest<IList<GetUpcomingModel>>
    {
    }
}
