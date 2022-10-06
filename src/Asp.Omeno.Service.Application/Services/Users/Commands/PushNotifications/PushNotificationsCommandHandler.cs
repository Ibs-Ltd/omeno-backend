using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications
{
    public class PushNotificationsCommandHandler : IRequestHandler<PushNotificationsCommand,Unit>
    {
        private readonly IPushNotification _pushService;
        public PushNotificationsCommandHandler(IPushNotification pushService)
        {
            _pushService = pushService ?? throw new ArgumentNullException(nameof(_pushService));
        }
        public async Task<Unit> Handle(PushNotificationsCommand request, CancellationToken cancellationToken)
        {
             await _pushService.Push(request);
            return Unit.Value;
        }

    }
}
