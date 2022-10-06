using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.AddBillingAddress
{
    public class AddBillingAddressCommandHandler : IRequestHandler<AddBillingAddressCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        public AddBillingAddressCommandHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddBillingAddressCommand request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == userId);
            if(!user.Addresses.Any(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS))
            {
                var billingAddress = new Address
                {
                    Id = Guid.NewGuid(),
                    AddressName = request.AddressName,
                    AddressNameTwo = request.AddressNameTwo,
                    AddressTypeId = AddressEnum.BILLING_ADDRESS,
                    UserId = userId,
                    CityName = request.City,
                    CountryName = request.Country,
                    PostalCode = request.PostalCode,
                };

                _context.Addresses.Add(billingAddress);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
