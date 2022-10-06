using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordUserCommand : IRequest
    {
        public string email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
