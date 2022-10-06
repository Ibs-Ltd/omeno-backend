using Asp.Omeno.Service.Application.Exceptions;
using Asp.Omeno.Service.Application.Helpers;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IServiceDbContext _context;
        public GetProfileQueryHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration, IServiceDbContext context)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetProfileModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var token = AuthHelper.GetTokenFromHeader();
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

                    if(isActive == true)
                    {
                        var user = await _context.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == Guid.Parse(response["sub"].ToString()));
                        return new GetProfileModel
                        {
                            UserId = Guid.Parse(response["sub"].ToString()),
                            FirstName = response["firstName"].ToString(),
                            LastName = response["lastName"].ToString(),
                            Email = response["email"].ToString(),
                            UserName = response["userName"].ToString(),
                            Active = response["active"].ToString(),
                            HasBillingAddress = user.Addresses.Any(x => x.AddressTypeId == AddressEnum.BILLING_ADDRESS)
                        };
                    }
                    return new GetProfileModel
                    {
                        Active = response["active"].ToString(),
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
