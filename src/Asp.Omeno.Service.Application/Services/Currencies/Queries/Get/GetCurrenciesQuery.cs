using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Currencies.Queries.Get
{
    public class GetCurrenciesQuery : IRequest<IList<GetCurrenciesModel>>
    {
    }
}
