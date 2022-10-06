using System;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.Get
{
    public class GetUsersModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
