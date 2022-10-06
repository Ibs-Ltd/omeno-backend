using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AcceptedTerms { get; set; }
        public Guid LanguageId { get; set; }
        public User AddUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                PhoneNumber = PhoneNumber,
                AcceptedTerms = AcceptedTerms,
                Tokens = 0,
                LanguageId = LanguageId,
            };
            return user;
        }
    }
}
