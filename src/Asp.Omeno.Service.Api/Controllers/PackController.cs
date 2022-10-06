using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Packs.Queries.Get;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/packs")]
    public class PackController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPacks([FromQuery] GetPacksQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
