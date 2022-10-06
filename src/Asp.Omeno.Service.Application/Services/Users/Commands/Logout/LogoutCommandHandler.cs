using Asp.Omeno.Service.Application.Helpers;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public LogoutCommandHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = AuthHelper.GetTokenFromHeader();
            IDictionary<string, string> command = new Dictionary<string, string>(){
                { "token", token }
            };
            var client = _httpClientFactory.CreateClient();
            using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, _configuration["Endpoints:Service"] + "/connect/revocation"))
            {
                message.Headers.Add("Accept", "application/x-www-form-urlencoded");
                message.Headers.Add("Authorization", _configuration["Authentication:RevocationAuth"]);
                message.Content = new FormUrlEncodedContent(command);
                await client.SendAsync(message);
            }
            
            return Unit.Value;
        }
    }
}
