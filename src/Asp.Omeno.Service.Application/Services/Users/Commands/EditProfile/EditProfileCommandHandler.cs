using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Helpers;
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

namespace Asp.Omeno.Service.Application.Services.Users.Commands.EditProfile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, Unit>
    {
        private readonly UserManager<User> _userManager;
        public EditProfileCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<Unit> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName.ToString());
            if(user != null )
            {
                var updateUser = request.EditProfile(user);
                await _userManager.UpdateAsync(updateUser);
                await UpdateUserClaims(user);
            }
            else
                throw new BadRequestException("userName is not available");

            return Unit.Value;
        }

        private async Task UpdateUserClaims(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            var newclaims = new List<Claim>
            {
                new Claim(UserClaimEnum.UserId, user.Id.ToString()),
                new Claim(UserClaimEnum.FirstName, user.FirstName),
                new Claim(UserClaimEnum.LastName, user.LastName),
                new Claim(UserClaimEnum.UserName, user.UserName),
                new Claim(ClaimTypes.Role, role.Value)
            };
            await _userManager.RemoveClaimsAsync(user, claims);
            await _userManager.AddClaimsAsync(user, newclaims);
        }
    }
}
