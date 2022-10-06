using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest
    {
        public Guid ID { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Quantity { get; set; }
        public Guid InvoiceStatus_ID { get; set; }
        public virtual  InvoiceType InvoiceType_ID { get; set; }
        public Guid Product_ID { get;set;}
        public Guid User_ID { get; set; }
    }
}
