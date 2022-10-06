using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.AutoBids.Commands.Add;
using Asp.Omeno.Service.Application.Services.AutoBids.Commands.Delete;
using Asp.Omeno.Service.Application.Services.Bids.Commands.Do;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/bids")]
    public class BidController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> DoBid([FromBody] DoBidCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":autobid")]
        public async Task<IActionResult> AddAutoBid([FromBody] AddAutoBidCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":cancel-bid")]
        public async Task<IActionResult> CancelBid([FromBody] DeleteAutoBidCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
