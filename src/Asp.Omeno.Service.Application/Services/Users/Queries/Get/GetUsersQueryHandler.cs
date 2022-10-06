using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.Get
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<GetUsersModel>>
    {
        private readonly IServiceDbContext _context;
        public GetUsersQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetUsersModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = from user in _context.Users
                         select user;

            if (request.Filter != null)
            {
                result = QueryConditionsFilter(request, result);
            }

            return await result
                .Include(x => x.UserRoles)
                .Where(x => x.UserRoles.FirstOrDefault().RoleId == request.RoleId)
                .Select(user => new GetUsersModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email
                }).Skip((request.Page - 1) * request.RowsPerPage)
                .Take(request.RowsPerPage).ToListAsync();
        }

        private static IQueryable<User> QueryConditionsFilter(GetUsersQuery request, IQueryable<User> result)
        {
            bool isAnyFound = false;

            string[] words = Regex.Split(request.Filter, @"\W+");
            foreach (string value in words)
            {
                if (value != "")
                {
                    if (result.Any(x => x.NormalizedEmail.Contains(value.ToUpper())))
                    {
                        result = result.Where(x => x.NormalizedEmail.Contains(value.ToUpper()));
                        isAnyFound = true;
                    }

                    if (result.Any(x => x.NormalizedUserName.Contains(value.ToUpper())))
                    {
                        result = result.Where(x => x.NormalizedUserName.Contains(value.ToUpper()));
                        isAnyFound = true;
                    }

                    if (result.Any(x => x.FirstName.Contains(value)))
                    {
                        result = result.Where(x => x.FirstName.Contains(value));
                        isAnyFound = true;
                    }

                    if (result.Any(x => x.LastName.Contains(value)))
                    {
                        result = result.Where(x => x.LastName.Contains(value));
                        isAnyFound = true;
                    }

                    if (result.Any(x => x.PhoneNumber.Contains(value)))
                    {
                        result = result.Where(x => x.PhoneNumber.Contains(value));
                        isAnyFound = true;
                    }
                }

            }

            if (isAnyFound == false)
                result = result.Where(x => x.FirstName == "NO USERS AVAILABLE");
            return result;
        }
    }
}
