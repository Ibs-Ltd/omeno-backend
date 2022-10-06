using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications
{
    public class PushNotificationsModel : INotification
    {
        public Guid UserId { get; set; }
    }
}
