using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Add
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public AddUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
        public async Task<AddUserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.AddUser();

            var createUser = await _userManager.CreateAsync(user, request.Password);
            if (!createUser.Succeeded) throw new SomethingWentWrongException();
            await CreateUserRole(user, request);

            await CreateUserClaims(user, request);

            return new AddUserModel
            {
                UserId = user.Id
            };
        }

        private async Task CreateUserClaims(User user, AddUserCommand request)
        {
            string role = await GetRoleName(request);
            var claims = new List<Claim>
            {
                new Claim(UserClaimEnum.UserId, user.Id.ToString()),
                new Claim(UserClaimEnum.FirstName, user.FirstName),
                new Claim(UserClaimEnum.LastName, user.LastName),
                new Claim(UserClaimEnum.UserName, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            await _userManager.AddClaimsAsync(user, claims);
        }

        private async Task CreateUserRole(User user, AddUserCommand request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        private async Task<string> GetRoleName(AddUserCommand request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            return role.Name;
        }
    }
}
