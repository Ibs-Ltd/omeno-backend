using Asp.Omeno.Service.Common.Extensions;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword
{
    public class ForgotPasswordAccountQueryHandler : INotificationHandler<ForgotPasswordAccountQuery>
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public ForgotPasswordAccountQueryHandler(UserManager<User> userManager,
            IConfiguration configuration,
            IMediator mediator)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task Handle(ForgotPasswordAccountQuery notification, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(notification.Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            var notifyEmail = new ForgotPasswordEmailNotification
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                URL = PrepareUrl(user.Email, token)
            };

            await _mediator.Publish(notifyEmail);

        }
        private string PrepareUrl(string email, string token)
        {
            var url = _configuration["Endpoints:ResetPassword"];

            token = token.Encode(Encoding.UTF8);

            IDictionary<string, string> placeholders = new Dictionary<string, string>()
            {
                { "<#EMAIL#>",email},
                { "<#TOKEN#>",token}
            };

            foreach (var placeholder in placeholders)
            {
                url = url.Replace(placeholder.Key, placeholder.Value);
            }

            return url;
        }

    }
}
