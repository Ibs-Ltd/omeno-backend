using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.Total
{
    public class GetTotalUsersQueryHandler : IRequestHandler<GetTotalUsersQuery, int>
    {
        private readonly IServiceDbContext _context;
        public GetTotalUsersQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> Handle(GetTotalUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .Include(x => x.UserRoles)
                .Where(x => x.UserRoles.FirstOrDefault().RoleId == request.RoleId)
                .ToListAsync();

            return users.Count;
        }
    }
}
