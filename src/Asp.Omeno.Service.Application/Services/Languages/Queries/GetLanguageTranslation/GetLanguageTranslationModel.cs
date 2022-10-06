using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Asp.Omeno.Service.Application.Services.Languages.Queries.GetLanguageTranslation
{
    public class GetLanguageTranslationModel : IRequest<OkObjectResult>
    {
        
        public string inputData { get; set; }
        public string languagePair { get; set; }
    }
}