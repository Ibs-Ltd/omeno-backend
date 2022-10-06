using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.Total
{
    public class GetTotalUsersQuery : IRequest<int>
    {
        public Guid RoleId { get; set; }
    }
}
