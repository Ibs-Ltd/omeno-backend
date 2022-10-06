using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Helpers;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, Unit>
    {
        private readonly UserManager<User> _userManager;
        public ChangePasswordUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<Unit> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var userEmail = await _userManager.FindByEmailAsync(request.email);
            var currentPassword = _userManager.PasswordHasher.VerifyHashedPassword(userEmail, userEmail.PasswordHash, request.CurrentPassword);
            if (!currentPassword.HasFlag(PasswordVerificationResult.Success))
            {
                throw new BadRequestException("Old password is incorrect");
            }
            var newPassword = _userManager.PasswordHasher.VerifyHashedPassword(userEmail, userEmail.PasswordHash, request.NewPassword);
            if (newPassword.HasFlag(PasswordVerificationResult.Success))
            {
                throw new BadRequestException("Password must not be same as old password");
            }
            var response = await _userManager.ChangePasswordAsync(userEmail, request.CurrentPassword, request.NewPassword);
            
            if (!response.Succeeded)
            {
                string error = response.Errors.FirstOrDefault().Description;
                throw new InternalValidationSignleException(error);
            };

            return Unit.Value;
        }
    }
}
