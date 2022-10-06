using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
