using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetTokenBalance
{
    public class GetTokenBalanceQuery : IRequest<GetTokenBalanceModel>
    {
    }

    public class GetTokenBalanceModel
    {
        public long Tokens { get; set; }
    }
}
