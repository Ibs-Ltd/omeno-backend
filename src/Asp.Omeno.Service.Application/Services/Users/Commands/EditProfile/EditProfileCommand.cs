using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.EditProfile
{
    public class EditProfileCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid LanguageId { get; set; }

        public User EditProfile(User user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;            
            user.DateOfBirth = DateOfBirth;
            user.PhoneNumber = PhoneNumber;            
            return user;
        }
    }
}
