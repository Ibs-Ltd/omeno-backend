using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ResetPassword
{
    public class ResetPasswordAccountCommand : INotification
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
