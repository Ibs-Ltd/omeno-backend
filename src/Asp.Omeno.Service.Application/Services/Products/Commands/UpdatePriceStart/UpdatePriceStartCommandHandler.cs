using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.UpdatePriceStart
{
    public class UpdatePriceStartCommandHandler : IRequestHandler<UpdatePriceStartCommand, Unit>
    {
        private readonly IServiceDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        HubConnection connection;
        public UpdatePriceStartCommandHandler(IServiceDbContext context, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public async Task<Unit> Handle(UpdatePriceStartCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(product != null)
            {
                product.PriceStart = request.PriceStart;
                await _context.SaveChangesAsync();
            }
            else throw new BadRequestException("Product is not available");

            return Unit.Value;
        }

    }
}
