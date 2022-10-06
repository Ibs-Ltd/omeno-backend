using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Languages.Queries.GetLanguageTranslation
{
    public class GetLanguageTranslationQuery : IRequest<IList<GetLanguageTranslationModel>>
    {
    }
}
