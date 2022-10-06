using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword
{
    public class ForgotPasswordAccountQuery : INotification
    {
        public string Email { get; set; }
    }
}
