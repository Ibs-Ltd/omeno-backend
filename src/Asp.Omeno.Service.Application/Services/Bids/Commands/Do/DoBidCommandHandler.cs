using Asp.Omeno.Service.Application.Helpers;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Common.Extensions;
using Asp.Omeno.Service.Domain.Entities;
using Asp.Omeno.Service.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Asp.Omeno.Service.Application.Services.Bids.Commands.Do
{
    public class DoBidCommandHandler : IRequestHandler<DoBidCommand, Unit>
    {
        private static IDictionary<Guid, Timer> timers = new Dictionary<Guid, Timer>();
        private readonly IServiceDbContext _context;
        private readonly IMemoryCache _memoryCache;
        HubConnection connection;
        public DoBidCommandHandler(IServiceDbContext context, IMemoryCache memoryCache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public async Task<Unit> Handle(DoBidCommand request, CancellationToken cancellationToken)
        {
            Guid userId = Guid.Empty;
            ProfileModel profileInfo = new ProfileModel();
            if (request.Profile != null)
            {
                userId = request.Profile.UserId;
                profileInfo = request.Profile;
            }
            else
            {
                userId = AuthHelper.GetAuthId();
                profileInfo = AuthHelper.GetProfile();
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var biders = await _context.Bids.Where(x => x.ProductId == request.ProductId).ToListAsync();
            var productsFromCache = (IList<ProductModel>)_memoryCache.Get(InMemoryCacheKeysEnum.PRODUCTS);
            var selectProduct = productsFromCache.FirstOrDefault(x => x.Id == request.ProductId);
            var lastBid = (BidProcessModel)_memoryCache.Get(request.ProductId);

            var newBid = new Bid
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                UserId = userId,
                TimeOfBid = request.TimeOfBid,
                IsLast = true,
                IsAutoBid = await IsAutoBid(request, userId)
            };
            
            if (lastBid != null)
            {
                if(lastBid.UserId != userId)
                {
                    var bider = new BidProcessModel
                    {
                        ProductId = request.ProductId,
                        UserId = userId,
                        TimeOfBid = request.TimeOfBid
                    };
                    _memoryCache.Set(request.ProductId, bider);
                    BidNow(request, userId, profileInfo, biders, productsFromCache, selectProduct, lastBid, newBid);
                }
            }
            else
            {
                var bider = new BidProcessModel
                {
                    ProductId = request.ProductId,
                    UserId = userId,
                    TimeOfBid = request.TimeOfBid
                };
                _memoryCache.Set(request.ProductId, bider);
                if (biders.Count > 0)
                {
                    var lastBiderInDb = biders.FirstOrDefault(x => x.IsLast == true);
                    if (lastBiderInDb.UserId != userId)
                    {
                        BidNow(request, userId, profileInfo, biders, productsFromCache, selectProduct, lastBid, newBid);
                    }
                }
                else
                {
                    BidNow(request, userId, profileInfo, biders, productsFromCache, selectProduct, lastBid, newBid);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        private void BidNow(DoBidCommand request, Guid userId, ProfileModel profileInfo, List<Bid> biders, IList<ProductModel> productsFromCache, ProductModel selectProduct, BidProcessModel lastBid, Bid newBid)
        {
            var bidInDb = biders.FirstOrDefault(x => x.IsLast == true);
            if (bidInDb != null) bidInDb.IsLast = false;

            var bidInCache = selectProduct.Biders.FirstOrDefault(x => x.IsLast == true);
            if (bidInCache != null) bidInCache.IsLast = false;

            _context.Bids.Add(newBid);

            selectProduct.Biders.Add(new BidModel
            {
                UserId = userId,
                FirstName = profileInfo.FirstName,
                LastName = profileInfo.LastName,
                UserName = profileInfo.UserName,
                IsLast = true
            });

            if (selectProduct.TimerFromDb < 0)
            {
                selectProduct.Timer = selectProduct.TimerFromDb;
                selectProduct.TimerFromDb = 0;
            }
            else
            {
                selectProduct.Timer = 10;
            }

            GetTimer(request, lastBid, productsFromCache, selectProduct);
        }

        private async Task<bool> IsAutoBid(DoBidCommand request, Guid userId)
        {
            var autobid = await _context.AutoBids.Where(x => x.UserId == userId).FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
            if(autobid != null)
            {
                return autobid.Active;
            }
            return false;
        }

        private void GetTimer(DoBidCommand request, BidProcessModel lastBid, IList<ProductModel> productsFromCache, ProductModel selectProduct)
        {
            if (timers.ContainsKey(request.ProductId))
            {
                timers[request.ProductId].Stop();
            }
            timers[request.ProductId] = new Timer();
            timers[request.ProductId].Elapsed += async (sender, e) => await CompleteBid(request, lastBid, productsFromCache, selectProduct); ;
            timers[request.ProductId].Interval = 1000;
            timers[request.ProductId].Enabled = true;
            timers[request.ProductId].AutoReset = true;
        }

        private async Task CompleteBid(DoBidCommand request, BidProcessModel lastBid, IList<ProductModel> productsFromCache, ProductModel selectProduct)
        {
            var configuration = ServiceHelper.GetConfiguration();
            var context = ServiceHelper.GetDbContext();
            connection = new HubConnectionBuilder()
               .WithUrl(configuration["Endpoints:Service"] + "/product")
               .Build();
            await connection.StartAsync();

            Random rnd = new Random();
            int newRandom = rnd.Next(3, 8);
            if (selectProduct.Timer <= newRandom)
            {
                var autobids = await context.AutoBids
                .Include(x => x.User)
                .Where(x => x.Active == true)
                .Where(x => x.ProductId == request.ProductId).ToListAsync();
                if (autobids.Count > 0)
                {
                    await CanAutoBid(request, configuration, autobids);
                }
                else
                {
                    if(await IsPriceOk(request, context) == false)
                    {
                        await HelperBid(request, context, configuration);
                    }
                }
            }

            //if() end time store time to db
            if (selectProduct.Timer == 0)
            {
                // store product sold
                timers[selectProduct.Id].Stop();

            }
            else
            {
                selectProduct.Timer -= 1;
            }

            _memoryCache.Set(InMemoryCacheKeysEnum.PRODUCTS, productsFromCache);
            await connection.InvokeAsync("GetProducts");
        }

        private async Task CanAutoBid(DoBidCommand request, IConfiguration configuration, List<AutoBid> autobids)
        {
            var httpClient = ServiceHelper.GetHttpClient();
            Random rand = new Random();
            var randomSelect = autobids[rand.Next(autobids.Count)];
            string token = await GetToken(configuration, httpClient);
            await InternalBid(request, configuration, httpClient, randomSelect, token);
        }

        private async Task InternalBid(DoBidCommand request, IConfiguration configuration, IHttpClientFactory httpClient, AutoBid randomSelect, string token)
        {
            var clientToBid = httpClient.CreateClient();
            var query = new DoAutobidCommand
            {
                ProductId = request.ProductId,
                TimeOfBid = DateTime.Now,
                Profile = new ProfileModel
                {
                    UserId = randomSelect.UserId,
                    FirstName = randomSelect.User.FirstName,
                    LastName = randomSelect.User.LastName,
                    UserName = randomSelect.User.UserName
                }
            };
            using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, configuration["Endpoints:Service"] + "/api/bids"))
            {
                message.Headers.Add("Accept", "application/json");
                message.Headers.Add("Authorization", "Bearer " + token);
                message.Content = new StringContent(query.Serialize(), Encoding.UTF8, "application/json");
                await clientToBid.SendAsync(message);
            }
        }

        private async Task<string> GetToken(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            string token = "";
            IDictionary<string, string> command = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials" },
                {"client_id", "omeno-internal-client" },
                {"client_secret", "omeno-internal" },
                {"scope", "omeno_service" },
            };

            var client = httpClient.CreateClient();

            using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, configuration["Endpoints:Service"] + "/connect/token"))
            {
                message.Content = new FormUrlEncodedContent(command);

                var requestApi = await client.SendAsync(message);

                if (requestApi.IsSuccessStatusCode)
                {
                    var response = await Utilities.GetResponseContent<IDictionary<string, string>>(requestApi);
                    Console.WriteLine(response);
                    token = response["access_token"];
                }
            }

            return token;
        }

        private async Task<bool> IsPriceOk(DoBidCommand request, IServiceDbContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            var bids = await context.Bids
                .Include(x => x.User)
                .ThenInclude(x => x.UserRoles)
                .Where(x => x.ProductId == request.ProductId)
                .ToListAsync();

            var getMeno = await context.Tokens.ToListAsync();

            var menoPerBid = getMeno.FirstOrDefault(x => x.Key == MenoEnum.MenoPerBid).Value;
            var priceOfMeno = getMeno.FirstOrDefault(x => x.Key == MenoEnum.PriceOfMeno).Value;

            double menos = 0;
            foreach(var bid in bids)
            {
                if(bid.User.UserRoles.FirstOrDefault().RoleId == RoleEnum.CUSTOMER)
                {
                    menos += menoPerBid;
                }
            }

            var totalPrice = menos * priceOfMeno;
            if (totalPrice <= product.Price)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task HelperBid(DoBidCommand request, IServiceDbContext context, IConfiguration configuration)
        {
            var httpClient = ServiceHelper.GetHttpClient();
            var users = await context.Users
                .Include(x => x.UserRoles)
                .Where(x => x.UserRoles.FirstOrDefault().RoleId == RoleEnum.HELPER)
                .ToListAsync();

            if(users.Count > 0)
            {
                Random rand = new Random();
                var selectRandomUser = users[rand.Next(users.Count)];
                string token = await GetToken(configuration, httpClient);
                await InternalHelperBid(request, configuration, httpClient, selectRandomUser, token);
            }
        }

        private async Task InternalHelperBid(DoBidCommand request, IConfiguration configuration, IHttpClientFactory httpClient, User selectRandomUser, string token)
        {
            var clientToBid = httpClient.CreateClient();
            var query = new DoAutobidCommand
            {
                ProductId = request.ProductId,
                TimeOfBid = DateTime.Now,
                Profile = new ProfileModel
                {
                    UserId = selectRandomUser.Id,
                    FirstName = selectRandomUser.FirstName,
                    LastName = selectRandomUser.LastName,
                    UserName = selectRandomUser.UserName
                }
            };
            using (HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, configuration["Endpoints:Service"] + "/api/bids"))
            {
                message.Headers.Add("Accept", "application/json");
                message.Headers.Add("Authorization", "Bearer " + token);
                message.Content = new StringContent(query.Serialize(), Encoding.UTF8, "application/json");
                await clientToBid.SendAsync(message);
            }
        }
    }
}
