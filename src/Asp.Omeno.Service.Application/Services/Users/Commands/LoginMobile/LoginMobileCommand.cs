using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.LoginMobile
{
    public class LoginMobileCommand : IRequest<LoginMobileModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginMobileModel
    {
        public string AccessToken { get; set; }
        public string ExpiredIn { get; set; }
        public string Schema { get; set; }
        public string RefreshToken { get; set; }
    }
}
