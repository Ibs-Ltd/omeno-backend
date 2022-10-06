using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Roles.Queries.Get;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/roles")]
    public class RoleController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRolesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
