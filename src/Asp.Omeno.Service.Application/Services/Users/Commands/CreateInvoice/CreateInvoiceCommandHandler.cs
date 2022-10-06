using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public CreateInvoiceCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.User_ID);
            if(user != null)
            {
                var createInvoiceData = new Invoice
                {
                    Status = request.Status,
                    CreatedAt = request.CreatedAt,
                    UpdatedAt = request.UpdatedAt,
                    Quantity = request.Quantity,
                    InvoiceTypeId = request.InvoiceStatus_ID,
                    InvoiceType = request.InvoiceType_ID,
                    ProductId = request.Product_ID,
                    UserId = request.User_ID
                };

                _context.Invoices.Add(createInvoiceData);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
