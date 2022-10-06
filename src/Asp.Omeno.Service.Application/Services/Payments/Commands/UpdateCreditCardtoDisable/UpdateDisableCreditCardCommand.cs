using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateCreditCardtoDisable
{
    public class UpdateCreditCardtoDisableCommand : IRequest
    {
        public Guid User_ID { get; set; }
        public string CardNumber { get; set; }
        public bool Status { get; set; }
        public string Holder { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
}
