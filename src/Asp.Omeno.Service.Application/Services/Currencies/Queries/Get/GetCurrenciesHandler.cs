using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Currencies.Queries.Get
{
    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, IList<GetCurrenciesModel>>
    {
        private readonly IServiceDbContext _context;
        public GetCurrenciesQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetCurrenciesModel>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _context.Currencies.Select(Currency => new GetCurrenciesModel
            {
                Id = Currency.Id,
                Name = Currency.Name,
                Status = Currency.Status,
                CreatedAt = Currency.CreatedAt,
                UpdatedAt = Currency.UpdatedAt,
                currencyRatio = Currency.currencyRatio
            }).ToListAsync();
            return currencies;
        }
    }
}
