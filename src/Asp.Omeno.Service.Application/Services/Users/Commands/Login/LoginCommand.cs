using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
