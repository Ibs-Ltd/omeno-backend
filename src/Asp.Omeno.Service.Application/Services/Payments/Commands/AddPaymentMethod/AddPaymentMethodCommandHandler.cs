using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Services.Users.Commands.AddBillingAddress;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Payments.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandHandler : IRequestHandler<AddPaymentMethodCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        private readonly IMediator _mediator;
        public AddPaymentMethodCommandHandler(IServiceDbContext context, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<Unit> Handle(AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.Id == userId);

            //if (!user.Addresses.Any(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS))
            //{
            //    await _mediator.Send(new AddBillingAddressCommand
            //    {
            //        AddressName = request.AddressName,
            //        AddressNameTwo = request.AddressNameTwo,
            //        City = request.City,
            //        Country = request.Country,
            //        PostalCode = request.PostalCode,
            //    });
            //}
            var options = new PaymentMethodCreateOptions {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {

                    Number = request.Number,
                    ExpMonth = request.ExpMonth,
                    ExpYear = request.ExpYear,
                    Cvc = request.Cvc,

                }
            };
            if (!user.Addresses.Any(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS))
            {
                options.BillingDetails = new PaymentMethodBillingDetailsOptions
                {
                    Name = request.Holder,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Address = new AddressOptions
                    {
                        City = request.City,
                        Country = request.Country,
                        PostalCode = request.PostalCode,
                    },
                };
            }
            else
            {
                options.BillingDetails = new PaymentMethodBillingDetailsOptions
                {
                    Name = request.Holder,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Address = new AddressOptions
                    {
                        City = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().CityName,
                        Country = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().CountryName,
                        PostalCode = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().PostalCode,
                    },
                };
            }

            var service = new PaymentMethodService();
            var response = service.Create(options);
            if(response.StripeResponse.StatusCode == HttpStatusCode.OK)
            {
                if (!user.Addresses.Any(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS))
                {
                    await _mediator.Send(new AddBillingAddressCommand
                    {
                        AddressName = request.AddressName,
                        AddressNameTwo = request.AddressNameTwo,
                        City = request.City,
                        Country = request.Country,
                        PostalCode = request.PostalCode,
                    });
                }
            }

            var getCustomer = new CustomerService();
            Customer customer;
            if(user.StripeCustomerId != null)
            {
                customer = getCustomer.Get(user.StripeCustomerId);
            }else
            {
                customer = CreateCustomer(user);
            }

            service.Attach(response.Id, new PaymentMethodAttachOptions
            {
                Customer = customer.Id,
            });

            var optionsToUpadte = new CustomerUpdateOptions
            {
                InvoiceSettings = new CustomerInvoiceSettingsOptions
                {
                    DefaultPaymentMethod = response.Id
                }
            };

            var updateCustomerService = new CustomerService();
            updateCustomerService.Update(customer.Id, optionsToUpadte);

            user.StripeCustomerId = customer.Id;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }

        private Customer CreateCustomer(User user)
        {
            var options = new CustomerCreateOptions
            {
                Name = user.FirstName + " " + user.LastName,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Address = new AddressOptions
                {
                    City = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().CityName,
                    Country = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().CountryName,
                    PostalCode = user.Addresses.Where(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS).FirstOrDefault().PostalCode,
                },
            };
            var service = new CustomerService();
            var response = service.Create(options);
            return response;
        }
    }
}
