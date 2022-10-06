namespace Asp.Omeno.Service.Application.Services.Users.Commands.Login
{
    public class LoginModel
    {
        public string AccessToken { get; set; }
        public string ExpiredIn { get; set; }
        public string Schema { get; set; }
        public string RefreshToken { get; set; }
    }
}
