using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateCreditCardtoDisable
{
    public class UpdateCreditCardtoDisableCommandHandler : IRequestHandler<UpdateCreditCardtoDisableCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public UpdateCreditCardtoDisableCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(UpdateCreditCardtoDisableCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            var paymentUpdate = await _context.Payments.FirstOrDefaultAsync(x => x.UserId== request.User_ID );
           
            if(paymentUpdate != null)
            {
                paymentUpdate.Status = request.Status;
                paymentUpdate.UserId = request.User_ID;
                paymentUpdate.CardNumber = request.CardNumber;
                paymentUpdate.CardHolder = request.Holder;
                paymentUpdate.Month = request.Month;
                paymentUpdate.Year = request.Year;
                await _context.SaveChangesAsync(cancellationToken);
            }
                
            else 
                throw new BadRequestException("UserId,cardNumber are not available");

            return Unit.Value;
        }
    }
}
