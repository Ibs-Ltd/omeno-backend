using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Languages.Queries.Get
{
    public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, IList<GetLanguageModel>>
    {
        private readonly IServiceDbContext _context;
        public GetLanguageQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetLanguageModel>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            var languages = await _context.Languages.Select(language => new GetLanguageModel
            {
                Id = language.Id,
                Name = language.Name
            }).ToListAsync();
            return languages;
        }
    }
}
