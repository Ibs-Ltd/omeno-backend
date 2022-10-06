using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Roles.Queries.Get
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IList<GetRolesModel>>
    {
        private readonly IServiceDbContext _context;
        public GetRolesQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetRolesModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.Select(role => new GetRolesModel 
            { 
                Id = role.Id,
                Name = role.Name
            }).ToListAsync();
            return roles;
        }
    }
}
