using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Currencies.Queries.Get;
using Asp.Omeno.Service.Application.Services.Payments.Commands.AddPaymentMethod;
using Asp.Omeno.Service.Application.Services.Payments.Commands.AddPrice;
using Asp.Omeno.Service.Application.Services.Payments.Commands.AddProduct;
using Asp.Omeno.Service.Application.Services.Payments.Commands.DeleteProduct;
using Asp.Omeno.Service.Application.Services.Payments.Commands.PayInvoice;
using Asp.Omeno.Service.Application.Services.Payments.Commands.UpdatePrice;
using Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateProduct;
using Asp.Omeno.Service.Application.Services.Payments.Queries.GetInvoices;
using Asp.Omeno.Service.Application.Services.Payments.Queries.GetPrices;
using Asp.Omeno.Service.Application.Services.Payments.Queries.GetStripeProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/payments")]
    public class PaymentController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet(":invoices")]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpGet(":prices")]
        public async Task<IActionResult> GetAllPrices([FromQuery] GetPricesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":products")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetStripeProductsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost(":price")]
        public async Task<IActionResult> CreatePrice([FromBody] AddPriceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [HttpPost(":payment-method")]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] AddPaymentMethodCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [HttpPost(":pay")]
        public async Task<IActionResult> PayInvoice([FromBody] PayInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost(":add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductStripeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpDelete(":delete-product")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductStripeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPut(":update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductStripeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPut(":update-price")]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdatePriceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet(":currencies")]
        public async Task<IActionResult> GetCurrencies([FromQuery] GetCurrenciesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}
