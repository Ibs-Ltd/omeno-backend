using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Constants;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Common.Extensions;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IServiceDbContext _context;
        public LoginCommandHandler(IHttpClientFactory httpClient,
            IConfiguration configuration,
            IServiceDbContext context)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<LoginModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user;
            if (ValidatorRegex.MatchRegex(ValidatorRegex.Email, request.Email))
            {
                user = await _context.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Email.ToUpper() == request.Email.ToUpper());
            }
            else
            {
                user = await _context.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.UserName.ToUpper() == request.Email.ToUpper());
            }

            if (user.UserRoles.First().RoleId != RoleEnum.ADMINISTRATOR)
            {
                throw new OnLoginFailureException();
            }
            else
            {
                IDictionary<string, string> command = new Dictionary<string, string>()
                {
                    {"grant_type", _configuration["Authentication:GrantType"] },
                    {"client_id", _configuration["Authentication:ClientId"] },
                    {"client_secret", _configuration["Authentication:ClientSecret"] },
                    {"scope", _configuration["Authentication:Scope"] },
                    {"username", user.UserName },
                    {"password", request.Password }
                };

                var client = _httpClient.CreateClient("HttpClientWithSSLUntrusted");

                using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, _configuration["Endpoints:Service"] + "/connect/token"))
                {
                    message.Content = new FormUrlEncodedContent(command);

                    var requestApi = await client.SendAsync(message);

                    if (requestApi.IsSuccessStatusCode)
                    {
                        var response = await Utilities.GetResponseContent<IDictionary<string, string>>(requestApi);
                        var refreshToken = "null";
                        if (response.ContainsKey("refresh_token")) refreshToken = response["refresh_token"];

                        return new LoginModel
                        {
                            AccessToken = response["access_token"],
                            Schema = response["token_type"],
                            ExpiredIn = response["expires_in"],
                            RefreshToken = refreshToken,
                        };
                    }
                    else
                    {
                        throw new OnLoginFailureException();
                    }
                }
            }

            
        }
    }
}
