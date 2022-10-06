using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Roles.Queries.Get
{
    public class GetRolesQuery : IRequest<IList<GetRolesModel>>
    {
    }
}
