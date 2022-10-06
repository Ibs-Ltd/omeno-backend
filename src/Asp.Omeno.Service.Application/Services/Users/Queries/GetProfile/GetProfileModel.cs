using System;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Active { get; set; }
        public bool HasBillingAddress { get; set; }
    }
}
