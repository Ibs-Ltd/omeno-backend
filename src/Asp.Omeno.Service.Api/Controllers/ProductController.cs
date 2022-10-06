using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Bids;
using Asp.Omeno.Service.Application.Services.Products;
using Asp.Omeno.Service.Application.Services.Products.Commands.Add;
using Asp.Omeno.Service.Application.Services.Products.Commands.DeleteImage;
using Asp.Omeno.Service.Application.Services.Products.Commands.DeleteProduct;
using Asp.Omeno.Service.Application.Services.Products.Commands.Update;
using Asp.Omeno.Service.Application.Services.Products.Commands.UpdatePriceStart;
using Asp.Omeno.Service.Application.Services.Products.Commands.UploadImages;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetAll;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetImages;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetSold;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetStatuses;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetSteps;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetTypes;
using Asp.Omeno.Service.Application.Services.Products.Queries.GetUpcoming;
using Asp.Omeno.Service.Application.Services.Products.Queries.Total;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost(":images")]
        public async Task<IActionResult> UploadImages()
        {
            var result = await Mediator.Send(new UploadImagesCommand());
            return Ok(result);
        }

        //[AllowAnonymous]
        //[HttpGet(":image")]
        //public async Task<IActionResult> ShowImage([FromQuery] ShowImageQuery query)
        //{
        //    var result = await Mediator.Send(query);

        //    return PhysicalFile(result.Image, result.ImageType);
        //}

        [Authorize(Roles = "Administrator")]
        [HttpGet(":images")]
        public async Task<IActionResult> GetAllImages([FromQuery] GetImagesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete(":image")]
        public async Task<IActionResult> DeleteImage([FromQuery] DeleteImageCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(":upcoming")]
        public async Task<IActionResult> GetUpcoming([FromQuery] GetUpcomingQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":count")]
        public async Task<IActionResult> GetTotal([FromQuery] GetTotalProductsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":statuses")]
        public async Task<IActionResult> GetStatuses([FromQuery] GetProductStatusesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":types")]
        public async Task<IActionResult> GetTypes([FromQuery] GetProductTypesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":steps")]
        public async Task<IActionResult> GetSteps([FromQuery] GetProductStepsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("SoldProduct")]
        public async Task<IActionResult> SoldProduct([FromQuery] GetSoldQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route(":set-price-start")]
        public async Task<IActionResult> SetPriceStart([FromQuery] UpdatePriceStartCommand query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
