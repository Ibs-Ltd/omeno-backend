using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications
{
    public class PushNotificationsCommand :  IRequest
    {
        public string Id { get; set; }
       
        public string UserName { get; set; }
        public string RegisterId { get; set; }
        public string FirebaseId { get; set; }
        public string Key { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string SenderId { get; set; }
        public string To { get; set; }

    }
}
