using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Languages.Queries.Get;
using Asp.Omeno.Service.Application.Services.Languages.Queries.GetLanguageTranslation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/languages")]
    public class LanguageController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLanguageQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route(":language-translation")]
        public async Task<OkObjectResult> translation([FromBody] GetLanguageTranslationModel query)
        {
            var result =await Mediator.Send(query);
            return result;
            //return Ok(result);
        }
    }
}
