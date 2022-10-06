using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.Omeno.Service.Api.Controllers.Base
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => (_mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>()));
    }
}
