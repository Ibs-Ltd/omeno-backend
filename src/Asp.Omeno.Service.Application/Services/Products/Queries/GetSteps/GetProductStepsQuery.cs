using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetSteps
{
    public class GetProductStepsQuery : IRequest<IList<GetProductStepsModel>>
    {
    }
}
