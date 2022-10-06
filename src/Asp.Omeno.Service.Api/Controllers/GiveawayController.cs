using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.GiveawayMembers.Commands.Add;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/giveaway")]
    public class GiveawayController : BaseController
    {
        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] AddGiveawayMemberCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
