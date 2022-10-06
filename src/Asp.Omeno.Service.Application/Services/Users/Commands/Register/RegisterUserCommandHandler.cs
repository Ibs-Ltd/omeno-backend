using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public RegisterUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
        public async Task<RegisterUserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.AddUser();

            var createUser = await _userManager.CreateAsync(user, request.Password);
            if (!createUser.Succeeded)
            {
                string error = createUser.Errors.FirstOrDefault().Description;
                throw new InternalValidationSignleException(error);
            };
            await CreateUserRole(user);

            await CreateUserClaims(user);

            return new RegisterUserModel
            {
                UserId = user.Id
            };
        }

        private async Task CreateUserClaims(User user)
        {
            string role = await GetRoleName();
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

        private async Task CreateUserRole(User user)
        {
            var role = await _roleManager.FindByIdAsync(RoleEnum.CUSTOMER.ToString());

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        private async Task<string> GetRoleName()
        {
            var role = await _roleManager.FindByIdAsync(RoleEnum.CUSTOMER.ToString());
            return role.Name;
        }
    }
}
