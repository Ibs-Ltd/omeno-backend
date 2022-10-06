using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace Asp.Omeno.Service.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { context.Exception.Message });

                return;
            }
            else if (context.Exception is InternalValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { context.Exception.Message });

                return;
            }
            else if (context.Exception is InternalValidationSignleException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { context.Exception.Message });

                return;
            }
            else if (context.Exception is OnLoginFailureException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { context.Exception.Message });

                return;
            }
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(new { context.Exception.Message });
        }
    }
}
