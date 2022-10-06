using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Omeno.Service.Application.Services.AutoBids.Commands.Delete
{
    public class DeleteAutoBidCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public Guid User_ID { get; set; }
        
    }
}
