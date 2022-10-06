using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Common.Extensions;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ResetPassword
{
    public class ResetPasswordAccountCommandHandler : INotificationHandler<ResetPasswordAccountCommand>
    {
        private readonly UserManager<User> _userManager;
        public ResetPasswordAccountCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task Handle(ResetPasswordAccountCommand notification, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(notification.Email);
            var oldPassword = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, notification.NewPassword);

            if (oldPassword.HasFlag(PasswordVerificationResult.Success))
            {
                throw new BadRequestException("Password must not be same as old password");
            }

            var token = notification.Token.Decode(Encoding.UTF8);
            var result = await _userManager.ResetPasswordAsync(user, token, notification.NewPassword);

            IList<string> errors = new List<string>();
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);

                }
                throw new InternalValidationException(errors);
            };

        }
    }
}
