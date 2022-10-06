using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword
{
    public class ForgotPasswordEmailNotification : INotification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
    }
}
