using MediatR;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetLiveBalance
{
    public class GetLiveBalanceQuery : IRequest<long>
    {
        public string Token { get; set; }
    }
}
