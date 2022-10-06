using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetLiveBalance
{
    public class GetLiveBalanceQueryHandler : IRequestHandler<GetLiveBalanceQuery, long>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IServiceDbContext _context;
        public GetLiveBalanceQueryHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration, IServiceDbContext context)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<long> Handle(GetLiveBalanceQuery request, CancellationToken cancellationToken)
        {
            var token = request.Token;
            IDictionary<string, string> command = new Dictionary<string, string>(){
                { "token", token }
            };
            var client = _httpClientFactory.CreateClient();
            using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, _configuration["Endpoints:Service"] + "/connect/introspect"))
            {
                message.Headers.Add("Accept", "application/x-www-form-urlencoded");
                message.Headers.Add("Authorization", _configuration["Authentication:IntrospectionAuth"]);
                message.Content = new FormUrlEncodedContent(command);
                var requestApi = await client.SendAsync(message);

                if (requestApi.IsSuccessStatusCode)
                {
                    var response = await Utilities.GetResponseContent<IDictionary<string, Object>>(requestApi);
                    bool isActive = false;
                    if (response.ContainsKey("sub")) isActive = Convert.ToBoolean(response["active"]);

                    if (isActive == true)
                    {
                        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(response["sub"].ToString()));
                        return user.Tokens;
                    }
                    throw new OnLoginFailureException();

                }
                else
                {
                    throw new OnLoginFailureException();
                }
            }
        }
    }
}
