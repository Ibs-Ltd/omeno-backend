using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.Get
{
    public class GetUsersQuery : IRequest<IList<GetUsersModel>>
    {
        public Guid RoleId { get; set; }
        public string Filter { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
    }
}
