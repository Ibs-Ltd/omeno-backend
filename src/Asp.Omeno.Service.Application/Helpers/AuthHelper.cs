using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Constants;
using Asp.Omeno.Service.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Asp.Omeno.Service.Application.Helpers
{
    public static class AuthHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public static string GetTokenFromHeader()
        {
            var headers = _httpContextAccessor.HttpContext.Request.Headers;
            if(headers.ContainsKey("Authorization"))
            {
                return headers["Authorization"].ToString().Substring(7);
            }
            return ValidatorMessages.NotFound("Authorization");
        }

        public static Guid GetAuthId()
        {
            if (!_httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.Any()) throw new UnauthorizedAccessException();

            string userId = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == UserClaimEnum.UserId).Value;

            return Guid.Parse(userId);
        }

        public static ProfileModel GetProfile()
        {
            if (!_httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.Any()) throw new UnauthorizedAccessException();

            string userId = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == UserClaimEnum.UserId).Value;
            string firstName = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == UserClaimEnum.FirstName).Value;
            string lastName = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == UserClaimEnum.LastName).Value;
            string userName = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == UserClaimEnum.UserName).Value;

            return new ProfileModel
            {
                UserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName,
                UserName = userName
            };
        }
    }
}
