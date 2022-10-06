using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Interfaces
{
    public interface IPushNotification
    {
        Task Push(PushNotificationsCommand model);
    }
}
