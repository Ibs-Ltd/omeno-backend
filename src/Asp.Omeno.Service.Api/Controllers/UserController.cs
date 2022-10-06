using Asp.Omeno.Service.Api.Controllers.Base;
using Asp.Omeno.Service.Application.Services.Payments.Commands.UpdateCreditCardtoDisable;
using Asp.Omeno.Service.Application.Services.Users.Commands.Add;
using Asp.Omeno.Service.Application.Services.Users.Commands.AddBillingAddress;
using Asp.Omeno.Service.Application.Services.Users.Commands.ChangeDefaultPaymentMethod;
using Asp.Omeno.Service.Application.Services.Users.Commands.ChangePassword;
using Asp.Omeno.Service.Application.Services.Users.Commands.CreateInvoice;
using Asp.Omeno.Service.Application.Services.Users.Commands.Delete;
using Asp.Omeno.Service.Application.Services.Users.Commands.EditProfile;
using Asp.Omeno.Service.Application.Services.Users.Commands.Login;
using Asp.Omeno.Service.Application.Services.Users.Commands.LoginMobile;
using Asp.Omeno.Service.Application.Services.Users.Commands.Logout;
using Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications;
using Asp.Omeno.Service.Application.Services.Users.Commands.Register;
using Asp.Omeno.Service.Application.Services.Users.Commands.ResetPassword;
using Asp.Omeno.Service.Application.Services.Users.Commands.Update;
using Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword;
using Asp.Omeno.Service.Application.Services.Users.Queries.Get;
using Asp.Omeno.Service.Application.Services.Users.Queries.GetCreditCards;
using Asp.Omeno.Service.Application.Services.Users.Queries.GetProfile;
using Asp.Omeno.Service.Application.Services.Users.Queries.GetTokenBalance;
using Asp.Omeno.Service.Application.Services.Users.Queries.Total;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        // [AllowAnonymous]
        [HttpPost(":forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromQuery] ForgotPasswordAccountQuery query)

        {
            await Mediator.Publish(query);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(":reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordAccountCommand command)
        {
            await Mediator.Publish(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(":login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(":mobile-login")]
        public async Task<IActionResult> Login([FromBody] LoginMobileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":logout")]
        public async Task<IActionResult> Logout()
        {
            var command = new LogoutCommand();
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route(":billing-address")]
        public async Task<IActionResult> AddBillindAddress([FromBody] AddBillingAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(":register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet(":profile")]
        public async Task<IActionResult> GetProfile([FromQuery] GetProfileQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet(":balance")]
        public async Task<IActionResult> GetProfileBalance([FromQuery] GetTokenBalanceQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet(":credit-cards")]
        public async Task<IActionResult> GetCreditCards([FromQuery] GetCreditCardsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet(":count")]
        public async Task<IActionResult> GetCount([FromQuery] GetTotalUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result); 
        }

        [HttpPut(":change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [HttpPut(":change-default-cc")]
        public async Task<IActionResult> ChangeDefaultCC([FromBody] ChangeDefaultPaymentMethodCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
        [HttpPut(":edit-profile")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }


        //[Authorize(Roles = "Administrator")]
        [HttpPut(":updatetoken")]
        public async Task<IActionResult> UpdateToken([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut(":creditcard-disable")]
        public async Task<IActionResult> creditCardDisable([FromBody] UpdateCreditCardtoDisableCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":push-notifications")]
        public async Task<IActionResult> PushNotifications([FromBody] PushNotificationsCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":create-invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
