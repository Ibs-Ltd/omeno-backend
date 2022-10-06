using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        //public string UserName { get; set; }
        public long Tokens { get; set; }
    }
}
