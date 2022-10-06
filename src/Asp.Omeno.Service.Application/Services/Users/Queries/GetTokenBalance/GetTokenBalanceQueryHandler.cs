using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetTokenBalance
{
    public class GetTokenBalanceQueryHandler : IRequestHandler<GetTokenBalanceQuery, GetTokenBalanceModel>
    {
        private readonly IServiceDbContext _context;
        public GetTokenBalanceQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetTokenBalanceModel> Handle(GetTokenBalanceQuery request, CancellationToken cancellationToken)
        {
            var userId = Helpers.AuthHelper.GetAuthId();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return new GetTokenBalanceModel
            {
                Tokens = user.Tokens
            };
        }
    }
}
