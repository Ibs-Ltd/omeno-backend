using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Languages.Queries.Get
{
    public class GetLanguageQuery : IRequest<IList<GetLanguageModel>>
    {
    }
}
